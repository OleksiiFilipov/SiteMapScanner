using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParserCommandManager.Models
{
    class BuildTreeCommand : Command
    {
        public string FilePath { get; set; }
    }
}
