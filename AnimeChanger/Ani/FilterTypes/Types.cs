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

    public struct RemoveFromStart
    {
        public char Char { get; set; }
    }

    public struct RemoveFromChar
    {
        public char Char { get; set; }
    }

    public struct RemoveInBetween
    {
        public char FirstChar { get; set; }
        public char LastChar { get; set; }
    }

    public struct BasicFilter
    {
        public string FilterWord { get; set; }
    }

    public struct BasicAdd
    {
        public string AddWord { get; set; }
    }

    public enum TypeInt
    {
        Replace = 0,
        Whitelist = 1,
        Blacklist = 2,
        RemoveFromStart = 4,
        RemoveFromChar = 8,
        RemoveInBetween = 16,
        BasicFilter = 32,
        BasicAdd = 64
    }
}
