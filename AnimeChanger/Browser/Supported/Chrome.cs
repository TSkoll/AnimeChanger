using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Automation;

namespace AnimeChanger.Browser.Supported
{
    public class Chrome : Browser
    {
        public string ProcessName { get; set; }
        public string[] RemoveBrowserTitles { get; set; }

        public string getURL(Process process)
        {
            AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
            AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));

            if (elmUrlBar != null)
            {
                AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                if (patterns.Length > 0)
                {
                    ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);
                    return val.Current.Value;
                }
            }

            return null;
        }
    }
}
