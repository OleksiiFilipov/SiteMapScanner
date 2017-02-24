using NLog;
using System;
using System.Diagnostics;
using System.Net;

namespace WebPageParser
{
    public class Downloader : IDownloader
    {
        Logger logger = LogManager.GetLogger("fileLogger");
        public long DownloadTime { get; set; }
        public string DownloadHtmlString(string soureUrl)
        {
            string result = string.Empty;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var stopWatch = Stopwatch.StartNew();
                    result = wc.DownloadString(soureUrl);
                    stopWatch.Stop();
                    DownloadTime = stopWatch.ElapsedMilliseconds;

                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return result;
        }
    }
}
