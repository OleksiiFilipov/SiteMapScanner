using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.ServiceHost.Models
{
    class BuildTreeCommand : Command
    {
        public string FilePath { get; set; }
        public override void Run(PageParser pParser)
        {
            pParser.BuildTree(this.Url, this.FilePath, this.WithExternalLinks);
        }
    }
}
