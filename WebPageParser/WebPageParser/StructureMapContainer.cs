using StructureMap;
using WebPageParser.DAL;

namespace WebPageParser
{
    public static class StructureMapContainer
    {
        //public static Container container = new Container(c =>
        //        c.Scan(scanner =>
        //        {
        //            scanner.TheCallingAssembly();
        //            scanner.WithDefaultConventions();
        //        }));

        public static Container Container = new Container(_ =>
        {
            _.For<ITreeBuilder>().Use<TreeBuilder>();
            _.For<IMultiThreadingParser>().Use<MultiThreadingParser>();
            _.For<IPageParserRepository>().Use<PageParserEntityRepository>();
            _.For<IMtPageParser>().Use<MtPageParser>();
            _.For<IDownloader>().Use<Downloader>();
            _.For<IContentParser>().Use<ContentParser>();
            _.For<IPageParserEFContext>().Use<PageParserEFContext>();
            _.For<IMultiThreadingQueue>().Use<HybridMultiThreadingQueue>();
            _.For<IObjectFactory>().Use<ObjectFactory>();
            _.For<IFileWriter>().Use<FileWriter>();
            _.For<IBulkSqlRepository>().Use<BulkSqlRepository>();
            _.For<IWppBulkSql>().Use<WppBulkSql>();
        });
    }
}

