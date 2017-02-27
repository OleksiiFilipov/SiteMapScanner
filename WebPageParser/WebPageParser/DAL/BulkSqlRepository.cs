using SqlBulkTools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WebPageParser.DAL
{
    class BulkSqlRepository:IBulkSqlRepository
    {
        private IWppBulkSql bulkSql;
        public BulkSqlRepository(IWppBulkSql bulkSql)
        {
            this.bulkSql = bulkSql;
        }
        public void QueueParamAddRange(IEnumerable<MultiThreadingQueueParam> paramList)
        {
            var bulk = new BulkOperations();
            using (TransactionScope trans = new TransactionScope())
            {
                PageParserEFContext c = new PageParserEFContext();
                var a = c.Database.Connection.ConnectionString;
                using (SqlConnection conn = new SqlConnection(bulkSql.ConnectionString))
                {
                    bulk.Setup<MultiThreadingQueueParam>()
                        .ForCollection(paramList)
                        .WithTable("MultiThreadingQueueParams")
                        .AddAllColumns()
                        .BulkInsert()
                        .SetIdentityColumn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }
    }
}
