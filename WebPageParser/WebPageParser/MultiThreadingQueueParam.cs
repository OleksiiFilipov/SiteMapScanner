using WebPageParser.Models;

namespace WebPageParser
{
    public class MultiThreadingQueueParam
    {
        public int Id { get; set; }
        public int nodId { get; set; }
        public string nodeUrl { get; set; }
        public int depth { get; set; }
        public bool withExternalLinks { get; set; }

        public MultiThreadingQueueParam()
        {

        }
        public MultiThreadingQueueParam(LinkNode node, int depth, bool withExternalLinks)
        {
            this.depth = depth;
            this.nodId = node.Id;
            this.nodeUrl = node.Url;
            this.withExternalLinks = withExternalLinks;
        }
    }
}
