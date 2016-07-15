using AnimeChanger.Ani;

namespace AnimeChanger
{
    public class Website
    {
        public string Keyword { get; set; }
        public string[] RemoveStrings { get; set; }
    }

    public class Website2
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public Filter[] Filters { get; set; }
    }
}
