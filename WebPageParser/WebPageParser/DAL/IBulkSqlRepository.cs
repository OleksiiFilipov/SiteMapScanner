using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.DAL
{
    interface IBulkSqlRepository
    {
        void QueueParamAddRange(IEnumerable<MultiThreadingQueueParam> paramList);
    }
}
