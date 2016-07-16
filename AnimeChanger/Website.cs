using AnimeChanger.Ani;

namespace AnimeChanger
{
    /// <summary>
    /// Class structure for website filters
    /// </summary>
    public class Website
    {
        public string Keyword { get; set; }
        public string Blacklist { get; set; }

        public Filter[] Filters { get; set; }
    }
}
