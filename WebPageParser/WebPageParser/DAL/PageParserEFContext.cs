using System.Data.Entity;
using WebPageParser.Models;

namespace WebPageParser.DAL
{
    public class PageParserEFContext : DbContext, IPageParserEFContext
    {
        public DbSet<LinkNode> LinkNodes { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<CssLink> CssLinks { get; set; }
        public DbSet<ImgLink> ImgLinks { get; set; }
        public DbSet<MultiThreadingQueueParam> MtParams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<LinkNode>().Property(p => p.Url).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
             modelBuilder.Entity<Site>().Property(p => p.Url).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
             modelBuilder.Entity<CssLink>().Property(p => p.Value).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
             modelBuilder.Entity<ImgLink>().Property(p => p.Value).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));*/
            modelBuilder.Entity<LinkNode>().HasMany(i => i.ImgLinks).WithMany(l => l.LinkNodes);
            modelBuilder.Entity<LinkNode>().HasMany(c => c.CssLinks).WithMany(l => l.LinkNodes);
            base.OnModelCreating(modelBuilder);
        }
    }
}
