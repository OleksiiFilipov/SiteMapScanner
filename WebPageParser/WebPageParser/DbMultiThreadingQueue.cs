using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageParser.DAL;

namespace WebPageParser
{
    class DbMultiThreadingQueue : IMultiThreadingQueue
    {
        private IObjectFactory factory;
        public DbMultiThreadingQueue(IObjectFactory factory)
        {
            this.factory = factory;
            using (var context = factory.CreateObject<IPageParserEFContext>())
            {
                context.MtParams.RemoveRange(context.MtParams);
            }
        }
        public int Count
        {
            get
            {
                using (var context = factory.CreateObject<IPageParserEFContext>())
                {
                    return context.MtParams.Count();
                }
            }
        }

        public void Enqueue(MultiThreadingQueueParam param)
        {
            using (var context = factory.CreateObject<IPageParserEFContext>())
            {
                context.MtParams.Add(param);
                context.SaveChanges();
            }
        }

        public bool TryDequeue(out MultiThreadingQueueParam param)
        {
            bool result = false;
            using (var context = factory.CreateObject<IPageParserEFContext>())
            {
                param = context.MtParams.First();
                if (param != default(MultiThreadingQueueParam))
                {
                    result = true;
                    context.MtParams.Remove(param);
                    context.SaveChanges();
                }
            }

            return result;
        }
    }
}
