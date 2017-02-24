using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.ServiceHost.Models
{
    class ParseCommand : Command
    {
        public int Depth { get; set; }
        public int ThreadsCount { get; set; }
        public override void Run(PageParser pParser)
        {
            pParser.Parse(this.Url, this.Depth, this.ThreadsCount, this.WithExternalLinks);
        }
    }
}
