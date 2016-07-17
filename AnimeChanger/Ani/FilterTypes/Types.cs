using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger.Ani.FilterTypes
{
    /// <summary>
    /// Class structure for "Replace" filter.
    /// Replaces a specified string to another specified string.
    /// </summary>
    public class Replace : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        public string Parse(string Title)
        {
            return Title.Replace(From, To);
        }
    }

    /// <summary>
    /// Class structure for "Remove from start" filter.
    /// Removes everything from the start of string to char (including the char).
    /// </summary>
    public class RemoveFromStart : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public char Char { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(0, Title.IndexOf(Char) + 1);
        }
    }

    /// <summary>
    /// Class structure for "Remove from char" filter.
    /// Removes everything from the char forward to the end of string (including the char).
    /// </summary>
    public class RemoveFromChar : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public char Char { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(Title.IndexOf(Char), Title.Length - Title.IndexOf(Char));
        }
    }

    /// <summary>
    /// Class structure for "Remove in between" filter.
    /// Removes a string in between of 2 characters.
    /// </summary>
    public class RemoveInBetween : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public char FirstChar { get; set; }
        public char LastChar { get; set; }

        public string Parse(string Title)
        {
            return Title.Remove(Title.IndexOf(FirstChar), Title.LastIndexOf(LastChar) - Title.IndexOf(FirstChar));
        }
    }

    /// <summary>
    /// Class structure for "Basic filter" filter.
    /// Removes a specified string from a string.
    /// </summary>
    public class BasicFilter : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public string FilterWord { get; set; }

        public string Parse(string Title)
        {
            return Title.Replace(FilterWord, "╚");
        }
    }

    /// <summary>
    /// Class structure for "Basic add" filter.
    /// Adds a word to the beginning of string.
    /// </summary>
    public class BasicAdd : Filter
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public string AddWord { get; set; }

        public string Parse(string Title)
        {
            return AddWord + Title;
        }
    }
}
