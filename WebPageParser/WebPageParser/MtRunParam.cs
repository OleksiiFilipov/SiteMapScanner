using System.Collections.Concurrent;

namespace WebPageParser
{
    public class MtRunParam
    {
        public string Url { get; set; }
        public IMultiThreadingQueue Queue { get; set; }
        public MtParserEvents MtParserEvents { get; set; }
        public ConcurrentDictionary<string, object> UsedUrlsList { get; set; }
    }
}
