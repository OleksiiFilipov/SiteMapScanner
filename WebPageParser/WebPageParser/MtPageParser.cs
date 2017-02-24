using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using WebPageParser.DAL;
using WebPageParser.Models;
using static WebPageParser.Helpers.LinkHelper;

namespace WebPageParser
{
    public class MtPageParser : IMtPageParser
    {
        public IMultiThreadingQueue queue;
        public MtParserEvents mtParserEvents;
        public ConcurrentDictionary<string, object> usedUrlsList;
        public string rootUrl;
        private IPageParserRepository pageParserRepository;
        private IObjectFactory factory;

        public string ParserName { get; set; }
        private int counter = 0;


        Logger logger = LogManager.GetLogger("fileLogger");
        Logger threadLogger = LogManager.GetLogger("threadLogger");
        public MtPageParser(IPageParserRepository pageParserRepository, IObjectFactory factory)
        {
            this.pageParserRepository = pageParserRepository;
            this.factory = factory;
        }

        public void ThreadRun(object p)
        {

            var parametr = (MtRunParam)p;
            this.queue = parametr.Queue;
            this.mtParserEvents = parametr.MtParserEvents;
            this.usedUrlsList = parametr.UsedUrlsList;
            this.rootUrl = parametr.Url;
            while (WaitHandle.WaitAny(mtParserEvents.EventArray) != 1)
            {
                RaiseWorkStartedEvent();
                try
                {
                    MultiThreadingQueueParam param;
                    queue.TryDequeue(out param);
                    if (param != null)
                    {
                        FillNodeFields(param);
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Exception {0}", e.ToString());
                }
                RaiseWorkFinishedEvent();
            }

        }

        private void FillNodeFields(MultiThreadingQueueParam param)
        {
            try
            {
                LinkNode node = pageParserRepository.GetNodeById(param.nodId);
                if (node == null) return;
                IDownloader downloader = factory.CreateObject<IDownloader>();
                string pageContent = downloader.DownloadHtmlString(node.Url);
                node.LoadTime = downloader.DownloadTime;
                if (pageContent != null)
                    node.HtmlSize = pageContent.Length * 2;
                IContentParser contentParser = factory.CreateObject<IContentParser>();
                contentParser.CreateDocument(pageContent, rootUrl);
                node.ImgLinks = contentParser.GetImages().Select(a => new ImgLink(a)).ToList();
                node.CssLinks = contentParser.GetCssFiles().Select(a => new CssLink(a)).ToList();
                List<string> links = contentParser.GetLinks().ToList();

                foreach (var item in links)
                {
                    if (!param.withExternalLinks && !IsInternal(item, rootUrl))
                    {
                        continue;
                    }
                    else
                    {
                        var IsAdded = usedUrlsList.TryAdd(item, null);
                        if (IsAdded)
                        {
                            if (node.ChildNodes == null)
                            {
                                node.ChildNodes = new List<LinkNode>();
                            }
                            if (node.ChildNodes.Count != 0)
                            {
                                var tempNode = node.ChildNodes.FirstOrDefault(cn => cn.Url == item);
                                if (tempNode == default(LinkNode))
                                {
                                    AddNewNode(node, item);
                                }
                            }
                            else
                            {
                                AddNewNode(node, item);
                            }
                        }
                    }
                }
               
                pageParserRepository.AddOrUpdateNode(node);

                foreach (var item in node.ChildNodes)
                {
                    if (param.depth < 0)
                    {
                        queue.Enqueue(new MultiThreadingQueueParam(item, param.depth, param.withExternalLinks));
                    }
                    else if (param.depth > 1)
                    {
                        queue.Enqueue(new MultiThreadingQueueParam(item, param.depth - 1, param.withExternalLinks));
                    }
                }
                //TODO:
                counter++;
                threadLogger.Debug("{0} counter:{1} parsed: {2}", ParserName, counter, node.Url);
                node.ChildNodes = null;
                node = null;
                downloader = null;
                contentParser.document = null;
                contentParser = null;
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        private void AddNewNode(LinkNode node, string url)
        {
            var tempNode = new LinkNode()
            {
                Url = url,
                IsInternal = true
            };

            tempNode.IsInternal = IsInternal(tempNode.Url, rootUrl);
            tempNode.RoorUrl = node.RoorUrl;
            node.ChildNodes.Add(tempNode);
        }


        protected virtual void RaiseWorkFinishedEvent()
        {
            WorkFinished?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void RaiseWorkStartedEvent()
        {
            WorkStarted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler WorkFinished;
        public event EventHandler WorkStarted;
    }
}
