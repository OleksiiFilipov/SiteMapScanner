namespace WebPageParserCommandManager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class WebPageParserCommandContext : DbContext
    {
        public WebPageParserCommandContext()
            : base("name=WebPageParserCommandContext")
        {
        }

        public virtual DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
