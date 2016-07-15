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

        public string Parse(string Title)
        {
            return Title.Replace(From, To);
        }
    }

    public class RemoveFromStart : Filter
    {
        public string Keyword { get; set; }

        public char Char { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(0, Title.IndexOf(Char) + 1);
        }
    }

    public class RemoveFromChar : Filter
    {
        public string Keyword { get; set; }

        public char Char { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(Title.IndexOf(Char), Title.Length - Title.IndexOf(Char));
        }
    }

    public class RemoveInBetween : Filter
    {
        public string Keyword { get; set; }

        public char FirstChar { get; set; }
        public char LastChar { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(Title.IndexOf(FirstChar), Title.LastIndexOf(LastChar) - Title.IndexOf(FirstChar));
        }
    }

    public class BasicFilter : Filter
    {
        public string Keyword { get; set; }

        public string FilterWord { get; set; }

        public string Parse(string Title)
        {
            return Title.Replace(FilterWord, "");
        }
    }

    public class BasicAdd : Filter
    {
        public string Keyword { get; set; }

        public string AddWord { get; set; }

        public string Parse(string Title)
        {
            return AddWord + Title;
        }
    }
}
