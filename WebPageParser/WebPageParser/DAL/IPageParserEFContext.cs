using System;
using System.Data.Entity;
using WebPageParser.Models;

namespace WebPageParser.DAL
{
    interface IPageParserEFContext : IDisposable
    {
        DbSet<LinkNode> LinkNodes { get; set; }
        DbSet<Site> Sites { get; set; }
        DbSet<CssLink> CssLinks { get; set; }
        DbSet<ImgLink> ImgLinks { get; set; }
        DbSet<MultiThreadingQueueParam> MtParams { get; set; }
        int SaveChanges();
    }
}
