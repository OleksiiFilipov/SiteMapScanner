using WebPageParser.Models;

namespace WebPageParser
{
    interface IMultiThreadingParser
    {
        void Start(Site site, int depth, int threadsCount, bool withExternalLinks = false);
    }
}
