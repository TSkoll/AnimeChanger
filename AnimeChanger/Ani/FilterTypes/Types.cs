using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger.Ani.FilterTypes
{
    public struct Replace
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public struct Whitelist
    {
        public string Keyword { get; set; }
        public bool Found { get; set; }
    }

    public struct Blacklist
    {
        public string Keyword { get; set; }
        public bool Found { get; set; }
    }
}
