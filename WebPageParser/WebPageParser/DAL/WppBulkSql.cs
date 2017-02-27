using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.DAL
{
    class WppBulkSql:IWppBulkSql
    {
        public string ConnectionString { get; set; }
        public WppBulkSql()
        {
            this.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=WebPageParser.DAL.PageParserEFContext;Integrated Security=True;MultipleActiveResultSets=True";
        }
    }
}
