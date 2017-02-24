using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.Models
{
    public class ImgLink
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<LinkNode> LinkNodes { get; set; }
        public ImgLink()
        {

        }
        public ImgLink(string value)
        {
            this.Value = value;
            this.LinkNodes = new List<LinkNode>();
        }
    }
}
