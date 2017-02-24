using HtmlAgilityPack;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using static WebPageParser.Helpers.LinkHelper;

namespace WebPageParser
{
    public class ContentParser:IContentParser
    {
        public string PageContent { get; private set; }
        private string rootUrl;
        public HtmlDocument document { get; set; }
        Logger logger = LogManager.GetLogger("fileLogger");
        public ContentParser()
        {
            
        }

        public void CreateDocument(string pageContent, string rootUrl)
        {
            try
            {
                this.PageContent = pageContent;
                this.rootUrl = rootUrl;
                this.document = new HtmlDocument();
                this.document.LoadHtml(PageContent);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        public ICollection<string> GetLinks()
        {
            return GetTagLinks("//a[@href]", "href");
        }

        public ICollection<string> GetImages()
        {
            return GetTagLinks("//img[@src]", "src");
        }

        public IEnumerable<string> GetCssFiles()
        {
            return GetTagLinks("//link[@rel='stylesheet']", "href");
        }

        private ICollection<string> GetTagLinks(string  pattern, string attribute)
        {
            ICollection<string> result;
            if (!string.IsNullOrEmpty(PageContent))
            {
                var nodes = document.DocumentNode.SelectNodes(pattern);
                if (nodes != null)
                    result = nodes.SelectMany(b => b?.Attributes.Where(c => c?.Name == attribute)).Select(d => FixUrl(d.Value, rootUrl)).Distinct().ToList();
                else
                    result = new List<string>();
            }

            else
            {
                result = new List<string>();
            }

            return result;
        }
    }
}
