using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPageParser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageParser;
using WebPageParser.Models;
using System.IO;
using Moq;

namespace WebPageParser.UnitTest
{
    [TestClass]
    public class TreeBuilderTest
    {
        [TestMethod]
        public void TestTReeBuild()
        {
            LinkNode root;
            root = new LinkNode();
            root.Id = 0;
            root.IsInternal = true;
            root.Url = "http://test.url";
            root.ChildNodes = new List<LinkNode>();
            LinkNode tempNode1 = new LinkNode();
            tempNode1.Id = 1;
            tempNode1.IsInternal = true;
            tempNode1.Url = "http://test.url/url1";
            tempNode1.ChildNodes = new List<LinkNode>();
            root.ChildNodes.Add(tempNode1);
            LinkNode tempNode2 = new LinkNode();
            tempNode2.Id = 2;
            tempNode2.IsInternal = true;
            tempNode2.Url = "http://test.url/url2";
            tempNode2.ChildNodes = new List<LinkNode>();
            LinkNode tempNode3 = new LinkNode();
            tempNode3.Id = 3;
            tempNode3.IsInternal = true;
            tempNode3.Url = "http://test.url/url3";
            tempNode3.ChildNodes = new List<LinkNode>();
            LinkNode tempNode4 = new LinkNode();
            tempNode4.Id = 4;
            tempNode4.IsInternal = true;
            tempNode4.Url = "http://test.url/url4";
            tempNode1.ChildNodes = new List<LinkNode>();
            tempNode3.ChildNodes.Add(tempNode4);
            tempNode2.ChildNodes.Add(tempNode3);
            root.ChildNodes.Add(tempNode2);


            string testUrl = "http://test.url";
            string testFileUrl = "testFile.txt";

            var pageParserRepositoryMock = new Mock<IPageParserRepository>();
            pageParserRepositoryMock.Setup(r=>r.GetNodeByUrl(testUrl)).Returns(root);
            pageParserRepositoryMock.Setup(r => r.GetNodeById(0)).Returns(root);
            pageParserRepositoryMock.Setup(r => r.GetNodeById(1)).Returns(tempNode1);
            pageParserRepositoryMock.Setup(r => r.GetNodeById(2)).Returns(tempNode2);
            pageParserRepositoryMock.Setup(r => r.GetNodeById(3)).Returns(tempNode3);
            pageParserRepositoryMock.Setup(r => r.GetNodeById(4)).Returns(tempNode4);

            ITreeBuilder tb = new TreeBuilder(pageParserRepositoryMock.Object);
            string expected = File.ReadAllText("expectedTestFile.txt");

            // act  
            tb.Build(testUrl, testFileUrl, false);
            string actual = File.ReadAllText("testFile.txt");

            // assert  

            Assert.AreEqual(expected, actual);
        }
    }
}
