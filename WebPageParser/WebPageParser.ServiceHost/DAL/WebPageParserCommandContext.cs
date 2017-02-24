using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageParser.ServiceHost.Models;

namespace WebPageParser.ServiceHost.DAL
{
    class WebPageParserCommandContext:DbContext
    {
        public DbSet<Command> Commands { get; set; }
    }
}
