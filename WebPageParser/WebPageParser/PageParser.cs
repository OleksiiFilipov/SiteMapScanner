using NLog;
using System;
using WebPageParser.Models;

namespace WebPageParser
{
    public class PageParser
    {
        public LoggingConfig lConfig;
        Logger logger;
        public PageParser()
        {
            this.lConfig = new LoggingConfig();
            logger = LogManager.GetLogger("fileLogger");
        }

        public void Parse(string url, int depth, int threadsCount, bool withExternalLinks = false)
        {
            try
            {
                logger.Info("Parsing started on {0} with depth {1}, {2} threads, with external links {3}",url, depth, threadsCount, withExternalLinks);
                Site site = new Site(url);
                IMultiThreadingParser parser = StructureMapContainer.Container.GetInstance<IMultiThreadingParser>();
                parser.Start(site, depth, threadsCount, withExternalLinks);
                logger.Info("Parsing finished on {0} with depth {1}, {2} threads, with external links {3}", url, depth, threadsCount, withExternalLinks);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        public void BuildTree(string url, string filePath, bool withExternalLinks = false)
        {
            try
            {
                logger.Info("Tree building started on {0} to {1}, with external links {2}", url,filePath, withExternalLinks);
                ITreeBuilder tb = StructureMapContainer.Container.GetInstance<ITreeBuilder>();
                tb.Build(url, filePath, withExternalLinks);
                logger.Info("Tree building finished on {0} to {1}, with external links {2}", url, filePath, withExternalLinks);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }
    }
}
