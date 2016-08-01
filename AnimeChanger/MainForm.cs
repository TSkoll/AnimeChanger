using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using Discord;

using AnimeChanger.Ani;

namespace AnimeChanger
{
    public partial class MainForm : MetroForm
    {
        #region Variables

        /// <summary>
        /// System tray icon.
        /// </summary>
        NotifyIcon notIcon = new NotifyIcon();

        /// <summary>
        /// List of supported browsers.
        /// </summary>
        public Browser[] supportedBrowsers =
        {
            new Browser { ProcessName = "chrome", RemoveBrowserTitles = new string[] { " - Google Chrome" } },
            new Browser { ProcessName = "firefox", RemoveBrowserTitles = new string[] { " - Mozilla Firefox", " - Firefox Developer Edition" } },
            new Browser { ProcessName = "waterfox", RemoveBrowserTitles = new string[] { " - Waterfox" } },
        };

        /// <summary>
        /// Last found title
        /// </summary>
        public string lastTitle = null;

        /// <summary>
        /// An array of global filters.
        /// </summary>
        public Filter[] globalFilters;

        /// <summary>
        /// An array of website filters.
        /// </summary>
        public Website[] webCache;

        /// <summary>
        /// Used for disconnecting from main thread.
        /// </summary>
        internal DiscordClient client;

        /// <summary>
        /// Used for calling MAL api.
        /// </summary>
        internal MalWrapper wrapper = new MalWrapper("animechangerbot", "iV6#mjlTIWln^&3f");

        /// <summary>
        /// Last api return from MyAnimeList.
        /// </summary>
        MalReturn lastTitleRet;

        private byte _retryInt = 0;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            Misc.CheckFolder();

            globalFilters = XML.GetGlobalFilters();
            webCache = XML.GetWebsiteFilters();

            #region system tray icon
            notIcon.Icon = Properties.Resources.appicon;
            notIcon.DoubleClick += new EventHandler(notIcon_DoubleClick);

            ContextMenu trayMenu = new ContextMenu();
            MenuItem CloseItem = new MenuItem();

            trayMenu.MenuItems.AddRange(
                new MenuItem[] { CloseItem });

            CloseItem.Index = 0;
            CloseItem.Text = "Close application";
            CloseItem.Click += new EventHandler((s, e) => {
                Application.Exit();
            });

            notIcon.ContextMenu = trayMenu;
            notIcon.Text = "AnimeChanger";
            notIcon.Visible = false;
            #endregion

            bMal.Hide();
        }

        #region Discord.net
        /// <summary>
        /// Starts Discord.DiscordClient, logs in and starts the check loop.
        /// </summary>
        public void StartClient(Secrets sec)
        {
            Secrets buffer = sec;
            Thread DiscordThread = new Thread(() =>
            {
                System.Timers.Timer CheckTimer = new System.Timers.Timer(7500);

                client = new DiscordClient();

                try
                {
                    client.ExecuteAndWait(async () =>
                    {
                        await client.Connect(buffer.id, buffer.pass);
                        TimerCheck();

                        bLogin.Invoke((MethodInvoker)delegate ()
                        {
                            bLogin.Enabled = false;
                            bLogin.Text = "Logged in";
                        });

                        CheckTimer.Elapsed += (s1, e1) => TimerCheck();
                        CheckTimer.Start();
                    });
                }
                catch (Discord.Net.HttpException ex)
                {
                    MessageBox.Show(string.Format("(Error: {0})\nCouldn't connect to Discord. Make sure you enter the correct email and password.", ex.GetType().ToString()), "Error");
                    if (File.Exists(Path.Combine(Misc.FolderPath, "secrets.xml")))
                    {
                        File.Delete(Path.Combine(Misc.FolderPath, "secrets.xml"));
                    }
                    RetryLogin();
                }

                return; // This should only run after Client.ExecuteAndWait fails/ends
            });
            DiscordThread.Name = "Spaghetti";
            DiscordThread.Start();
        }

        /// <summary>
        /// Passes login information from LoginForm to DiscordThread.
        /// </summary>
        /// <param name="sec">AnimeChanger.Secrets, login information.</param>
        public void PassSecrets(Secrets sec)
        {
            StartClient(sec);
        }
        #endregion

        #region Browser handling
        #region Process stuff
        /// <summary>
        /// Returns one single process of (first) keyword match found.
        /// </summary>
        /// <param name="Processes">System.Tuple of Browser and Process, browser processes currently running.</param>
        /// <returns>System.Tuple of Browser, Process, Website; Everything you can gather from scraping a thread.</returns>
        public Tuple<Browser, Process, Website> GetKeywordProcess(Tuple<Browser, Process>[] Processes)
        {
            foreach (var pair in Processes)
            {
                foreach (var w in webCache)
                {
                    if (w.Blacklist != null)
                        if (pair.Item2.MainWindowTitle.ToLower().Contains(w.Blacklist.ToLower()))
                            continue;

                    if (pair.Item2.MainWindowTitle.ToLower().Contains(w.Keyword))
                        return new Tuple<Browser, Process, Website>(pair.Item1, pair.Item2, w);
                }
            }
            return null;
        }

        /// <summary>
        /// Gets browser processes running currently on the system
        /// </summary>
        /// <returns>An array of System.Tuple of Browser and Process, every browser process running on the system</returns>
        public Tuple<Browser, Process>[] GetBrowserProcesses()
        {
            Process[] processes = Process.GetProcesses();

            List<Tuple<Browser, Process>> ret = new List<Tuple<Browser, Process>>();

            foreach (var b in supportedBrowsers)
            {
                foreach (var p in processes)
                {
                    if (p.ProcessName.Contains(b.ProcessName))
                        ret.Add(new Tuple<Browser, Process>(b, p));
                }
            }

            if (ret.Count != 0)
                return ret.ToArray();
            else
                return null;
        }
        #endregion

        /// <summary>
        /// Removes everything unnecessary from browser window title
        /// </summary>
        /// <param name="fullTitle">Full title of the browser window</param>
        /// <param name="usedBrowser">AnimeChanger.Browser, browser thread where the title was gathered</param>
        /// <param name="usedSite">AnimeChanger.Website, website where the anime is being watched</param>
        /// <returns>System.String, parsed string</returns>
        public string RemoveWebString(string fullTitle, Browser usedBrowser, Website usedSite)
        {
            var retString = fullTitle;
            foreach (string s in usedBrowser.RemoveBrowserTitles)
            {
                retString = retString.Replace(s, "");
            }

            if (globalFilters != null)
            {
                foreach (Filter filter in globalFilters)
                {
                    if (filter.Blacklist != null)
                        if (fullTitle.ToLower().Contains(filter.Blacklist.ToLower()))
                            continue;

                    if (filter.Keyword != null)
                    {
                        if (fullTitle.ToLower().Contains(filter.Keyword.ToLower()))
                        {
                            retString = filter.Parse(retString);
                        }
                    }
                    else
                        retString = filter.Parse(retString);
                }
            }

            foreach (var filter in usedSite.Filters)
            {
                if (filter.Blacklist != null)
                    if (fullTitle.ToLower().Contains(filter.Blacklist.ToLower()))
                        continue;

                if (filter.Keyword != null)
                {
                    if (fullTitle.ToLower().Contains(filter.Keyword.ToLower()))
                    {
                        retString = filter.Parse(retString);
                    }
                }
                else
                    retString = filter.Parse(retString);
            }

            retString = retString.Remove(retString.IndexOf("╚"), retString.LastIndexOf("╚") - retString.IndexOf("╚") + 1);

            return retString;
        }
        #endregion

        #region Other
        /// <summary>
        /// Main timer loop
        /// </summary>
        /// <param name="client">Discord.DiscordClient, used to assign the status</param>
        internal void TimerCheck()
        {
            var BrowserProcesses = GetBrowserProcesses();

            if (BrowserProcesses == null)
                return;

            var rightProcess = GetKeywordProcess(BrowserProcesses);

            if (rightProcess == null)
            {
                if (_retryInt >= 3)
                {
                    if (lastTitle != null)
                    {
                        ChangeGame(null);
                        lastTitle = null;

                        lastTitleRet = null;
                        pCover.Image = Properties.Resources.noAni;
                    }

                    _retryInt = 3;
                }

                _retryInt++;
                return;
            }
            else
            {
                _retryInt = 0;
            }

            var title = RemoveWebString(rightProcess.Item2.MainWindowTitle, rightProcess.Item1, rightProcess.Item3);

            if (title == null)
                return;

            if (title != lastTitle)
            {
                ChangeGame(title);

                var apiReturn = wrapper.GetMALTitle(title);
                pCover.Image = apiReturn.Cover;

                lastTitleRet = apiReturn;
            }

            lastTitle = title;
        }
        #endregion

        #region Cross thread
        internal void ChangeGame(string text)
        {
            lTitle.Invoke((MethodInvoker)delegate
            {
                lTitle.Text = "Currently watching: " + (text ?? "nothing ヾ(｡>﹏<｡)ﾉﾞ✧*。");
                notIcon.Text = "Currently watching: " + (text ?? "nothing ヾ(｡>﹏<｡)ﾉﾞ✧*。");
            });
            client.SetGame(text);
        }

        internal void RetryLogin()
        {
            Invoke((MethodInvoker)delegate
            {
                bLogin.Text = "Please wait...";
                bLogin.Enabled = false;

                System.Timers.Timer stop_police = new System.Timers.Timer(5000);
                stop_police.AutoReset = false;
                stop_police.Elapsed += (delegate {
                    bLogin.Invoke((MethodInvoker)delegate {
                        bLogin.Text = "Log in";
                        bLogin.Enabled = true;
                        bLogin_Click(this, new EventArgs());

                        stop_police.Stop();
                        stop_police.Dispose();
                    });
                });
                stop_police.Start();
            });
        }
        #endregion

        #region Events
        private void bLogin_Click(object sender, EventArgs e)
        {
            Secrets buffer = null;

            bLogin.Enabled = false;
            bLogin.Text = "Logging in...";

            if (!File.Exists(Misc.DiscordData))
            {
                using (LoginForm login = new LoginForm("discord"))
                {
                    login.ShowDialog();
                    buffer = login.Sec;
                }
            }
            else
            {
                Secrets sec = Misc.ReadSecrets("discord");
                if (sec != null)
                {
                    buffer = sec;
                }
                else
                {
                    File.Delete(Misc.DiscordData);
                    RetryLogin();
                }
            }

            if (buffer != null)
                StartClient(buffer);
            else
            {
                bLogin.Enabled = true;
                bLogin.Text = "Log in";
            }
        }

        private void bMal_Click(object sender, EventArgs e)
        {
            Secrets buffer = null;

            bMal.Enabled = false;
            bMal.Text = "Connecting...";

            if (!File.Exists(Misc.MalData))
            {
                using (LoginForm connect = new LoginForm("mal"))
                {
                    connect.ShowDialog();
                    buffer = connect.Sec;
                }
            }
            else
            {
                Secrets sec = Misc.ReadSecrets("mal");
                if (sec != null)
                {
                    buffer = sec;
                }
                else
                {
                    File.Delete(Misc.MalData);
                    bMal_Click(this, new EventArgs());
                }
            }

            if (buffer != null)
            {
                wrapper.Authenticate(buffer.id, buffer.pass);
            }
            else
            {
                bMal.Enabled = true;
                bMal.Text = "Connect with MAL";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.SetGame(null);
                client.Disconnect();
            }
        }

        #region minimization
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notIcon.Visible = true;
                Hide();
            }
        }

        private void notIcon_DoubleClick(object Sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notIcon.Visible = false;
        }
        #endregion

        private void pCover_DoubleClick(object sender, EventArgs e)
        {
            if (lastTitleRet != null)
            {
                Process.Start($"http://myanimelist.net/anime/{lastTitleRet.id}");
            }
        }
        #endregion
    }
}
