using WebPageParser.Models;

namespace WebPageParser.DAL
{
    public interface IPageParserRepository
    {
        void AddOrUpdateNode(LinkNode node);
        LinkNode GetNodeByUrl(string url);
        LinkNode GetNodeById(int id);
        Site GetOrCreateSite(Site site);
    }
}
