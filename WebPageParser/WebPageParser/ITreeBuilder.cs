namespace WebPageParser
{
    public interface ITreeBuilder
    {
        void Build(string rootUrl, string filePath, bool useExternal = false);
    }
}
