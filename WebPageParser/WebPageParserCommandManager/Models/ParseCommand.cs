using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParserCommandManager.Models
{

    class ParseCommand : Command
    {
        public int Depth { get; set; }
        public int ThreadsCount { get; set; }
    }
}
