using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
    public class LocaMultiThreadingQueue : IMultiThreadingQueue
    {
        private ConcurrentQueue<MultiThreadingQueueParam> queue = new ConcurrentQueue<MultiThreadingQueueParam>();
        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        public void Enqueue(MultiThreadingQueueParam param)
        {
            queue.Enqueue(param);
        }

        public bool TryDequeue(out MultiThreadingQueueParam param)
        {
            return queue.TryDequeue(out param);
        }
    }

}
