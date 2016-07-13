using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger.Ani.FilterTypes
{
    public class Replace
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class RemoveFromStart
    {
        public char Char { get; set; }
    }

    public class RemoveFromChar
    {
        public char Char { get; set; }
    }

    public class RemoveInBetween
    {
        public char FirstChar { get; set; }
        public char LastChar { get; set; }
    }

    public class BasicFilter
    {
        public string FilterWord { get; set; }
    }

    public class BasicAdd
    {
        public string AddWord { get; set; }
    }
}
