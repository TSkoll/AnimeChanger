using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger
{
    public class Browser
    {
        public string ProcessName { get; set; }
        public string RemoveBrowserTitle { get; set; }
        public Action method { get; set; } 
    }
}
