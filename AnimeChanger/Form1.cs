using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Discord;

using AnimeChanger.Ani;
using AnimeChanger.Ani.FilterTypes;

namespace AnimeChanger
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// List of supported browsers.
        /// </summary>
        public Browser[] SupportedBrowsers =
        {
            new Browser { ProcessName = "chrome", RemoveBrowserTitles = new string[] { " - Google Chrome" } },
            new Browser { ProcessName = "firefox", RemoveBrowserTitles = new string[] { " - Mozilla Firefox", " - Firefox Developer Edition" } },
            new Browser { ProcessName = "waterfox", RemoveBrowserTitles = new string[] { " - Waterfox" } },
        };

        /// <summary>
        /// Last found title
        /// </summary>
        string lastTitle = null;

        /// <summary>
        /// List of AnimeChanger.Website(s) loaded to memory.
        /// </summary>
        List<Website> WebCache = new List<Website>();

        /// <summary>
        /// Global filters loaded to memory
        /// </summary>
        Filter[] GlobalFilters;

        /// <summary>
        /// Cache of websites loaded to memory
        /// </summary>
        Website2[] WebCache2;

        /// <summary>
        /// Used for disconnecting from main thread.
        /// </summary>
        DiscordClient Client;

        public Form1()
        {
            InitializeComponent();

            Misc.CheckFolder();
            foreach (Website w in Misc.ReadXML())
            {
                WebCache.Add(w);
            }

            GlobalFilters = XML.GetGlobalFilters();
            WebCache2 = XML.GetWebsiteFilters();
        }

        #region Discord.Net

        /// <summary>
        /// Starts Discord.DiscordClient, logs in and starts the check loop.
        /// </summary>
        public void StartClient()
        {
            Thread DiscordThread = new Thread(() =>
            {
                System.Timers.Timer CheckTimer = new System.Timers.Timer(5000);

                Client = new DiscordClient();

                //Client.Ready += (s, e) =>
                //{
                //    ChangeStatusLabel("Logged in");
                //    CheckTimer.Elapsed += (s1, e1) => TimerCheck();
                //    CheckTimer.Start();
                //};

                //Client.ExecuteAndWait(async () =>
                //{
                //    await Client.Connect(Secrets.email, Secrets.password);
                //});

                ChangeStatusLabel("Logged in");
                CheckTimer.Elapsed += (s1, e1) => TimerCheck();
                CheckTimer.Start();

                //return; // This should only run after Client.ExecuteAndWait fails/ends
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
        public Tuple<Browser, Process, Website2> GetKeywordProcess(Tuple<Browser, Process>[] Processes)
        {
            foreach (var pair in Processes)
            {
                foreach (var w in WebCache2) // WebCache fallback still a possibility
                {
                    if (pair.Item2.MainWindowTitle.ToLower().Contains(w.Keyword))
                        return new Tuple<Browser, Process, Website2>(pair.Item1, pair.Item2, w);
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
        public string RemoveWebString(string fullTitle, Browser usedBrowser, Website2 usedSite)
        {
            var retString = fullTitle;
            foreach (string s in usedBrowser.RemoveBrowserTitles)
            {
                retString = retString.Replace(s, "");
            }
            

            foreach (var filter in usedSite.Filters)
            {
                if (fullTitle.ToLower().Contains(filter.Keyword.ToLower()))
                {
                    retString = filter.Parse(retString);
                }
            }

            //foreach (string filter in usedSite.RemoveStrings)
            //{
            //    retString = retString.Replace(filter, "");
            //}

            

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
                return;

            var title = RemoveWebString(rightProcess.Item2.MainWindowTitle, rightProcess.Item1, rightProcess.Item3);

            if (title == null)
                return;

            if (title != lastTitle)
            {
                Client.SetGame(new Game(title));
                ChangeTextboxText(title);
            }

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

        #region Events
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            WebCache.Clear();
            foreach (Website w in Misc.ReadXML())
            {
                WebCache.Add(w);
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        private void Client_Closing(object sender, FormClosingEventArgs e)
        {
            Client.Disconnect();
        }
        #endregion
    }
}
