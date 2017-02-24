using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser.UnitTest
{
    [TestClass]
    public class ContentParserTest
    {
        [TestMethod]
        public void TestGetLinks()
        {
            // arrange  
            string testRootUrl = "https://developer.microsoft.com";
            string testPageData = File.ReadAllText("1.html");
            ContentParser cParser = new ContentParser();
            cParser.CreateDocument(testPageData, testRootUrl);
            List<string> expected = new List<string>();
            expected.Add("https://developer.microsoft.com/link1");
            expected.Add("https://developer.microsoft.com/link2");
            expected.Add("https://developer.microsoft.com/link3");

            // act  
            List<string> actual = cParser.GetLinks().ToList();

            // assert  
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetImgs()
        {
            // arrange  
            string testRootUrl = "https://developer.microsoft.com";
            string testPageData = File.ReadAllText("1.html");
            ContentParser cParser = new ContentParser();
            cParser.CreateDocument(testPageData, testRootUrl);
            List<string> expected = new List<string>();
            expected.Add("http://someimg/src1");

            // act  
            List<string> actual = cParser.GetImages().ToList();

            // assert  
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCss()
        {
            // arrange  
            string testRootUrl = "https://developer.microsoft.com";
            string testPageData = File.ReadAllText("1.html");
            ContentParser cParser = new ContentParser();
            cParser.CreateDocument(testPageData, testRootUrl);
            List<string> expected = new List<string>();
            expected.Add("https://developer.microsoft.com/styles/style.css");

            // act  
            List <string> actual = cParser.GetCssFiles().ToList();

            // assert  
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
