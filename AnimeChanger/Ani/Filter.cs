﻿namespace AnimeChanger.Ani
{
    public interface Filter
    {
        string Keyword { get; set; }
        string Blacklist { get; set; }

        string Parse(string Title);
    }
}