using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger.Ani.FilterTypes
{
    public class Replace : Filter
    {
        public string Keyword { get; set; }

        public string From { get; set; }
        public string To { get; set; }
    }

    public class RemoveFromStart : Filter
    {
        public string Keyword { get; set; }

        public char Char { get; set; }
    }

    public class RemoveFromChar : Filter
    {
        public string Keyword { get; set; }

        public char Char { get; set; }
    }

    public class RemoveInBetween : Filter
    {
        public string Keyword { get; set; }

        public char FirstChar { get; set; }
        public char LastChar { get; set; }
    }

    public class BasicFilter : Filter
    {
        public string Keyword { get; set; }

        public string FilterWord { get; set; }
    }

    public class BasicAdd : Filter
    {
        public string Keyword { get; set; }

        public string AddWord { get; set; }
    }
}
