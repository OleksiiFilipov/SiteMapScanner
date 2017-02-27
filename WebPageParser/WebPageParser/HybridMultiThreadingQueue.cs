using EntityFramework.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WebPageParser.DAL;

namespace WebPageParser
{
    class HybridMultiThreadingQueue : IMultiThreadingQueue
    {
        private ConcurrentQueue<MultiThreadingQueueParam> queue = new ConcurrentQueue<MultiThreadingQueueParam>();
        private ConcurrentBag<MultiThreadingQueueParam> bag = new ConcurrentBag<MultiThreadingQueueParam>();
        private IBulkSqlRepository bulkRepository;
        private bool IsDbQueueEmpty = true;
        public HybridMultiThreadingQueue(IBulkSqlRepository bulkRepo)
        {
            this.bulkRepository = bulkRepo;

            using (var context = new PageParserEFContext())
            {
                context.MtParams.Delete();
                context.SaveChanges();
            }
            Thread qManagerThread = new Thread(ManageQueue);
            qManagerThread.Start();
        }

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        public void Enqueue(MultiThreadingQueueParam param)
        {
            if (queue.Count < 200 && IsDbQueueEmpty && bag.Count == 0)
            {
                queue.Enqueue(param);
            }
            else
            {
                bag.Add(param);
            }
        }

        public bool TryDequeue(out MultiThreadingQueueParam param)
        {
            return queue.TryDequeue(out param);
        }

        private void ManageQueue()
        {
            Thread.Sleep(10000);
            if (queue.Count < 500)
            {
                using (var context = new PageParserEFContext())
                {
                    var tempList = context.MtParams.OrderBy(mp => mp.Id).Take(200);
                    if (tempList?.Count() == 200)
                    {
                        IsDbQueueEmpty = false;
                    }
                    else if (bag.Count == 0)
                    {
                        IsDbQueueEmpty = true;
                    }

                    if (tempList?.Count() > 0)
                    {
                        foreach (var item in tempList)
                        {
                            queue.Enqueue(item);
                        }
                        context.MtParams.RemoveRange(tempList);
                        context.SaveChanges();
                    }
                }
            }

            if (bag.Count > 0)
            {
                List<MultiThreadingQueueParam> tempList = new List<MultiThreadingQueueParam>();
                lock (bag)
                {
                    tempList.AddRange(bag);
                    bag = new ConcurrentBag<MultiThreadingQueueParam>();
                }
                bulkRepository.QueueParamAddRange(tempList);
            }

            ManageQueue();
        }
    }
}
