using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.Models
{
    public class CssLink
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<LinkNode> LinkNodes { get; set; }
        public CssLink()
        {

        }

        public CssLink(string value)
        {
            this.Value = value;
            this.LinkNodes = new List<LinkNode>();
        }
    }
}
