using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Discord;

namespace AnimeChanger
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// List of supported browsers.
        /// </summary>
        public Browser[] SupportedBrowsers =
        {
            new Browser { ProcessName = "chrome", RemoveBrowserTitle = " - Google Chrome" },
            new Browser { ProcessName = "firefox", RemoveBrowserTitle = " - Mozilla Firefox" },
            new Browser { ProcessName = "waterfox", RemoveBrowserTitle = " - Waterfox" },
            new Browser { ProcessName = "firefox developer edition", RemoveBrowserTitle = " - Firefox Developer Edition" }
        };

        /// <summary>
        /// Last found title
        /// </summary>
        string lastTitle = null;

        /// <summary>
        /// List of AnimeChanger.Website(s) loaded to memory.
        /// </summary>
        List<Website> WebCache = new List<Website>();

        public Form1()
        {
            InitializeComponent();

            Misc.CheckFolder();
            foreach (Website w in Misc.ReadXML())
            {
                WebCache.Add(w);
            }

            StartClient();
        }

        #region Discord.Net

        /// <summary>
        /// Starts Discord.DiscordClient, logs in and starts the check loop.
        /// </summary>
        public void StartClient()
        {
            Thread DiscordThread = new Thread(() =>
            {
                System.Timers.Timer CheckTimer = new System.Timers.Timer(30000);

                DiscordClient Client = new DiscordClient();

                Client.Ready += (s, e) =>
                {
                    ChangeStatusLabel("Logged in");
                    CheckTimer.Elapsed += (s1, e1) => TimerCheck(Client);
                    CheckTimer.Start();
                };

                Client.ExecuteAndWait(async () =>
                {
                    await Client.Connect(Secrets.email, Secrets.password);
                });
            });
            DiscordThread.Name = "Spaghetti";
            DiscordThread.Start();
        }
        #endregion

        #region idk
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
                foreach (var w in WebCache)
                {
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

            foreach (var b in SupportedBrowsers)
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
            var retString = fullTitle.Replace(usedBrowser.RemoveBrowserTitle, "");
            
            foreach (string filter in usedSite.RemoveStrings)
            {
                retString = retString.Replace(filter, "");
            }
            return retString;
        }
        #endregion

        #region Other
        /// <summary>
        /// Main timer loop
        /// </summary>
        /// <param name="client">Discord.DiscordClient, used to assign the status</param>
        internal void TimerCheck(DiscordClient client)
        {
            var BrowserProcesses = GetBrowserProcesses();

            if (BrowserProcesses == null)
                return;

            var rightProcess = GetKeywordProcess(BrowserProcesses);

            if (rightProcess == null)
                return;

            var title = RemoveWebString(rightProcess.Item2.MainWindowTitle, rightProcess.Item1, rightProcess.Item3);

            if (title == null)
                return;

            if (title != lastTitle)
            {
                client.SetGame(new Game(title));
                ChangeTextboxText(title);
            }

            //if (title != lastTitle)
            //    MessageBox.Show(title);
            //else
            //    MessageBox.Show("Last title!");

            lastTitle = title;
        }
        #endregion

        #region Cross Thread Talking
        internal void ChangeTextboxText(string text)
        {
            TitleBox.Invoke((MethodInvoker)delegate {
                TitleBox.Text = text;
            });
        }

        internal void ChangeStatusLabel(string text)
        {
            StatusLabel.Invoke((MethodInvoker)delegate {
                StatusLabel.Text = text;
            });
        }
        #endregion
    }
}
