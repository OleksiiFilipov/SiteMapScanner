using NLog;
using System;
using System.Collections.Concurrent;
using System.Threading;
using WebPageParser.DAL;
using WebPageParser.Models;

namespace WebPageParser
{
    public class MultiThreadingParser : IMultiThreadingParser
    {
        private IMultiThreadingQueue parsingQueue;
        private ConcurrentDictionary<string, object> usedUrlsList;
        private MtParserEvents mtParserEvents;
        private IPageParserRepository repository;
        private int threadsAvailable;
        private IObjectFactory factory;
        Logger logger = LogManager.GetLogger("fileLogger");
        public MultiThreadingParser(IPageParserRepository repository, IMultiThreadingQueue parsingQueue, IObjectFactory factory)
        {
            mtParserEvents = new MtParserEvents();
            this.repository = repository;
            this.parsingQueue = parsingQueue;
            this.factory = factory;
            this.threadsAvailable = 0;
        }

        public void Start(Site site, int depth, int threadsCount, bool withExternalLinks = false)
        {
            try
            {
                usedUrlsList = new ConcurrentDictionary<string, object>();
                site = repository.GetOrCreateSite(site);
                parsingQueue.Enqueue(new MultiThreadingQueueParam(site.Root, depth, withExternalLinks));
                usedUrlsList.TryAdd(site.Url, null);
                
                for (int i = 0; i < threadsCount; i++)
                {
                    IMtPageParser parser = factory.CreateObject<IMtPageParser>();
                    MtRunParam parametr = new MtRunParam()
                    {
                        MtParserEvents = mtParserEvents,
                        Queue = parsingQueue,
                        Url = site.Url,
                        UsedUrlsList = usedUrlsList
                    };
                    parser.ParserName = $"Parser {i}";
                    parser.WorkFinished += ParserOnWorkFinished;
                    parser.WorkStarted += ParserOnWorkStarted;
                    Thread parserThread = new Thread(new ParameterizedThreadStart(parser.ThreadRun));
                    parserThread.Name = $"Parser {i}";
                    threadsAvailable++;
                    parserThread.Start(parametr);
                }
                //TODO:
                site = null;
                while (true)
                {
                    if (threadsAvailable > 0 && parsingQueue.Count > 0)
                    {
                        mtParserEvents.AvailableItemEvent.Set();
                    }
                    else if (threadsAvailable == threadsCount && parsingQueue.Count == 0)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }

                mtParserEvents.ExitThreadEvent.Set();
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }


        private void ParserOnWorkStarted(object sender, EventArgs e)
        {
            this.threadsAvailable--;
        }

        private void ParserOnWorkFinished(object sender, EventArgs e)
        {
            this.threadsAvailable++;
        }
    }
}
