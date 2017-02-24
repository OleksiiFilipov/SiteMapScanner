namespace WebPageParser
{
    public interface IMultiThreadingQueue
    {
        int Count { get; }
        void Enqueue(MultiThreadingQueueParam param);
        bool TryDequeue(out MultiThreadingQueueParam param);
    }
}
