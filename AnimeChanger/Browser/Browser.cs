using System.Diagnostics;

namespace AnimeChanger.Browser
{
    public interface Browser
    {
        string ProcessName { get; set; }
        string[] RemoveBrowserTitles { get; set; }

        string getURL(Process process);
    }
}
