using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.Models
{
    public class Site
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public LinkNode Root { get; set; }
        public Site()
        {

        }
        public Site(string url)
        {
            this.Url = url;
            this.Root = new LinkNode(url);
            this.Root.RoorUrl = url;
        }
    }
}
