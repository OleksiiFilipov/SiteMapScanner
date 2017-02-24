using System.Collections.Generic;

namespace WebPageParser
{
    public interface IContentParser
    {
        HtmlAgilityPack.HtmlDocument document { get; set; }
        void CreateDocument(string pageContent, string rootUrl);
        ICollection<string> GetLinks();
        ICollection<string> GetImages();
        IEnumerable<string> GetCssFiles();

    }
}
