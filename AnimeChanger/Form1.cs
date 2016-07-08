using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Discord;

namespace AnimeChanger
{
    public partial class Form1 : Form
    {
        private Browser[] SupportedBrowsers =
        {
            new Browser { ProcessName = "chrome", RemoveBrowserTitle = " - Google Chrome", method = HandleChrome},
            new Browser { ProcessName = "firefox", RemoveBrowserTitle = " - Mozilla Firefox", method = null },
            new Browser { ProcessName = "waterfox", RemoveBrowserTitle = " - Waterfox",  method = null },
            new Browser { ProcessName = "firefox developer edition", RemoveBrowserTitle = " - Firefox Developer Edition", method = null }
        };

        List<Website> WebCache = new List<Website>();
        Browser foundBrowser = null;
        string lastTitle = null;

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
        public void StartClient()
        {
            //Thread DiscordThread = new Thread(() => {
            //    System.Timers.Timer CheckTimer = new System.Timers.Timer(5000);

            //    DiscordClient Client = new DiscordClient();

            //    Client.Ready += (s, e) =>
            //    {
            //        firstRun();
            //        CheckTimer.Elapsed += (s1, e1) => TimerCheck(Client);
            //        CheckTimer.Start();
            //    };

            //    Client.ExecuteAndWait(async () =>
            //    {
            //        await Client.Connect(Secrets.email, Secrets.password);
            //    });
            //});
            //DiscordThread.Name = "Spaghetti";
            //DiscordThread.Start();
        }
        #endregion

        #region idk
        public Process[] GetBrowserProcesses()
        {
            List<Process> matches = new List<Process>();
            Process[] processes = Process.GetProcesses();
            foreach (var b in SupportedBrowsers)
            {
                foreach (var p in processes)
                {
                    if (p.ProcessName.Contains(b.ProcessName))
                        matches.Add(p);
                }
            }
            return matches.ToArray();
        }

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

        #region BrowserHandling
        public static void HandleChrome()
        {
            var p = GetProcess("chrome");

        }
        #endregion

        #region Browser peeking
        private static Process GetProcess(string processName)
        {
            Process retProcess = null;

            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process p in processes)
            {
                if (!string.IsNullOrWhiteSpace(p.MainWindowTitle))
                {
                    retProcess = p;
                    break;
                }
            }

            return retProcess;
        }
        #endregion

        #region Other
        internal void firstRun()
        {
            foundBrowser = GetBrowser();
        }

        internal void TimerCheck(DiscordClient client)
        { 

        }
        #endregion
    }
}
