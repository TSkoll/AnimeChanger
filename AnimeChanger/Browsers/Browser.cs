namespace AnimeChanger
{
    /// <summary>
    /// Class structure for supported browsers.
    /// </summary>
    public interface Browser
    {
        string ProcessName { get; set; }
        string[] RemoveBrowserTitles { get; set; }

        string getURL();
    }
}
