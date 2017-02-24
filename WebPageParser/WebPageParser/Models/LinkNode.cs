using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.Models
{
    public class LinkNode:IDisposable
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoorUrl { get; set; }
        public string Url { get; set; }
        //public int? ParentId { get; set; }
        //public LinkNode Parent { get; set; }
        public virtual List<LinkNode> ChildNodes { get; set; }
        public virtual ICollection<CssLink> CssLinks { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
        public long LoadTime { get; set; }
        public long HtmlSize { get; set; }
        public bool IsInternal { get; set; }

        private bool disposed = false;


        public LinkNode()
        {
        }
        public LinkNode(string url)
        {
            this.Url = url;
            this.IsInternal = true;
        }


        public void CopyData(LinkNode node)
        {
            this.HtmlSize = node.HtmlSize;
            this.IsInternal = node.IsInternal;
            this.LoadTime = node.LoadTime;
            this.Url = node.Url;
            //this.ChildNodes = node.ChildNodes;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Parent?.Dispose();
                }

                disposed = true;
            }
        }

        ~LinkNode()
        {
            Dispose(false);
        }
    }
}
