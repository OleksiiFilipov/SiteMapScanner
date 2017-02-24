using System.Threading;

namespace WebPageParser
{
    public class MtParserEvents
    {
        public MtParserEvents()
        {

            availableItemEvent = new AutoResetEvent(false);
            exitThreadEvent = new ManualResetEvent(false);
            eventArray = new WaitHandle[2];
            eventArray[0] = availableItemEvent;
            eventArray[1] = exitThreadEvent;
        }

        public EventWaitHandle ExitThreadEvent
        {
            get { return exitThreadEvent; }
        }
        public EventWaitHandle AvailableItemEvent
        {
            get { return availableItemEvent; }
        }
        public WaitHandle[] EventArray
        {
            get { return eventArray; }
        }

        private EventWaitHandle availableItemEvent;
        private EventWaitHandle exitThreadEvent;
        private WaitHandle[] eventArray;
    }
}
