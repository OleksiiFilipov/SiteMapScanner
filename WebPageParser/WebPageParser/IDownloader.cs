namespace WebPageParser
{
    interface IDownloader
    {
        long DownloadTime { get; set; }
        string DownloadHtmlString(string soureUrl);
    }
}
