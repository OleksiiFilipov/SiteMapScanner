using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPageParser.Models;

namespace WebPageParser.DAL
{
    class PageParserEntityRepository : IPageParserRepository
    {
        private IObjectFactory factory;
        Logger logger = LogManager.GetLogger("fileLogger");

        public PageParserEntityRepository(IObjectFactory factory)
        {
            this.factory = factory;
        }
        private void AddLinkNode(LinkNode node, IPageParserEFContext context)
        {
            try
            {
                List<CssLink> cssList = new List<CssLink>();
                List<ImgLink> imgList = new List<ImgLink>();
                foreach (var item in node.CssLinks)
                {
                    cssList.Add(AddOrGetCssLink(item.Value, context));
                }
                node.CssLinks = cssList;
                foreach (var item in node.ImgLinks)
                {
                    imgList.Add(AddOrGetImgLink(item.Value, context));
                }
                node.ImgLinks = imgList;
                context.LinkNodes.Add(node);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        public void AddOrUpdateNode(LinkNode node)
        {
            try
            {
                using (var context = factory.CreateObject<IPageParserEFContext>())
                {
                    var tempNode = GetNodeById(node.Id, context);
                    if (tempNode == default(LinkNode))
                    {
                        AddLinkNode(node, context);
                    }

                    else
                    {
                        tempNode.CopyData(node);
                        foreach (var childNode in node.ChildNodes)
                        {
                            var tempChild = tempNode.ChildNodes.FirstOrDefault(ch => ch.Url == childNode.Url);
                            if(tempChild==default(LinkNode))
                            {
                                tempNode.ChildNodes.Add(childNode);
                            }
                        }
                        List<CssLink> cssList = new List<CssLink>();
                        List<ImgLink> imgList = new List<ImgLink>();
                        foreach (var item in node.CssLinks)
                        {
                            cssList.Add(AddOrGetCssLink(item.Value, context));
                        }
                        tempNode.CssLinks = cssList;
                        foreach (var item in node.ImgLinks)
                        {
                            imgList.Add(AddOrGetImgLink(item.Value, context));
                        }
                        tempNode.ImgLinks = imgList;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {

                logger.Error("Exception {0}", e.ToString());
            }
        }

        private CssLink AddOrGetCssLink(string value, IPageParserEFContext context)
        {
            var tempCss = new CssLink();
            try
            {
                tempCss = context.CssLinks.FirstOrDefault(c => c.Value == value);
                if (tempCss == default(CssLink))
                {
                    tempCss = new CssLink(value);
                    context.CssLinks.Add(tempCss);
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }

            return tempCss;

        }

        private ImgLink AddOrGetImgLink(string value, IPageParserEFContext context)
        {
            var tempImg = new ImgLink();
            try
            {
                tempImg = context.ImgLinks.FirstOrDefault(c => c.Value == value);
                if (tempImg == default(ImgLink))
                {
                    tempImg = new ImgLink(value);
                    context.ImgLinks.Add(tempImg);
                }

            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempImg;
        }

        public LinkNode GetNodeByUrl(string url)
        {
            var tempNode = new LinkNode();
            try
            {
                using (var context = factory.CreateObject<IPageParserEFContext>())
                {
                    tempNode = context.LinkNodes.Include("ChildNodes").Include("CssLinks").Include("ImgLinks").FirstOrDefault(n => n.Url == url);
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempNode;
        }

        private LinkNode GetNodeByUrl(string url, IPageParserEFContext context)
        {
            var tempNode = new LinkNode();
            try
            {
                tempNode = context.LinkNodes.Include("ChildNodes").Include("CssLinks").Include("ImgLinks").FirstOrDefault(n => n.Url == url);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempNode;
        }

        public LinkNode GetNodeById(int id)
        {
            var tempNode = new LinkNode();
            try
            {
                using (var context = factory.CreateObject<IPageParserEFContext>())
                {
                    tempNode = context.LinkNodes.Include("ChildNodes").Include("CssLinks").Include("ImgLinks").FirstOrDefault(n => n.Id == id);
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempNode;
        }

        private LinkNode GetNodeById(int id, IPageParserEFContext context)
        {
            var tempNode = new LinkNode();
            try
            {
                tempNode = context.LinkNodes.Include("ChildNodes").Include("CssLinks").Include("ImgLinks").FirstOrDefault(n => n.Id == id);
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempNode;
        }

        public Site GetOrCreateSite(Site site)
        {
            var tempSite = new Site();
            try
            {
                using (var context = factory.CreateObject<IPageParserEFContext>())
                {
                    tempSite = context.Sites.Include("Root").FirstOrDefault(s => s.Url == site.Url);
                    if (tempSite == default(Site))
                    {
                        tempSite = site;
                        context.Sites.Add(tempSite);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
            return tempSite;
        }
    }
}
