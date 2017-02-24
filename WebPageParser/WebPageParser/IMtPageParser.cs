using System;

namespace WebPageParser
{
    interface IMtPageParser
    {
        string ParserName { get; set; }
        void ThreadRun(object p);
        event EventHandler WorkFinished;
        event EventHandler WorkStarted;
    }
}
