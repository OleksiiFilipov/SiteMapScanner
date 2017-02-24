using NLog;
using System;
using System.IO;
using System.Text;
using WebPageParser.DAL;
using WebPageParser.Models;

namespace WebPageParser
{
    public class TreeBuilder : ITreeBuilder
    {
        private IPageParserRepository repository;
        private IFileWriter fileWriter;
        private string filePath;
        Logger logger = LogManager.GetLogger("fileLogger");
        public TreeBuilder (IPageParserRepository repository, IFileWriter fWrilter)
        {
            this.repository = repository;
            this.fileWriter = fWrilter;
        }

        public void Build(string rootUrl, string filePath, bool useExternal = false)
        {
            try
            {
                this.filePath = filePath;
                StringBuilder result = new StringBuilder();
                LinkNode root = repository.GetNodeByUrl(rootUrl);
                if (root != default(LinkNode))
                {
                    fileWriter.CreateFile(filePath);
                    RecutsiveBuilser(root, 0, ref result, useExternal);
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }

        private void RecutsiveBuilser(LinkNode node, int depthCounter, ref StringBuilder resultString, bool useExternal)
        {
            try
            {
                if (!useExternal && !node.IsInternal)
                {
                    return;
                }
                node = repository.GetNodeById(node.Id);
                resultString.Append("| ").Append('-', depthCounter).Append(' ').Append(node.Url).Append("\r\n").ToString();
                fileWriter.AppendText(filePath, resultString.ToString());
                resultString.Clear();
                if (node.ChildNodes.Count > 0)
                {
                    foreach (var item in node.ChildNodes)
                    {
                        RecutsiveBuilser(item, depthCounter + 1, ref resultString, useExternal);
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error("Exception {0}", e.ToString());
            }
        }
    }
}
