using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPageParser.Helpers;

namespace WebPageParser.UnitTest
{
    [TestClass]
    public class LinkHelperTest
    {
        [TestMethod]
        public void TestFixUrl()
        {
            // arrange  
            string testRootUrl = "https://google.com";

            string testUrl = "";
            string testUrl2 = "/";
            string testUrl3 = "/someurl1/someurl2";
            string testUrl4 = " ";
            string testUrl5 = "https://google.com/someurl1/someurl2";

            string expected = "https://google.com/";
            string expected2 = "https://google.com/";
            string expected3 = "https://google.com/someurl1/someurl2";
            string expected4 = "https://google.com/";
            string expected5 = "https://google.com/someurl1/someurl2";
            // act  
            string actual = LinkHelper.FixUrl(testUrl, testRootUrl);
            string actual2 = LinkHelper.FixUrl(testUrl2, testRootUrl);
            string actual3 = LinkHelper.FixUrl(testUrl3, testRootUrl);
            string actual4 = LinkHelper.FixUrl(testUrl4, testRootUrl);
            string actual5 = LinkHelper.FixUrl(testUrl5, testRootUrl);


            // assert  

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
            Assert.AreEqual(expected5, actual5);
        }


        [TestMethod]
        public void TestIsInternal()
        {
            // arrange  
            string testRootUrl = "https://google.com";

            string testUrl = "https://google.com/someurl1/someurl2";
            string testUrl2 = "https://google.negugl.com/someurl1/someurl2";
            string testUrl3 = "https://yandex.ua/someurl1/someurl2";

            bool expected = true;
            bool expected2 = false;
            bool expected3 = false;

            // act  
            bool actual = LinkHelper.IsInternal(testUrl, testRootUrl);
            bool actual2 = LinkHelper.IsInternal(testUrl2, testRootUrl);
            bool actual3 = LinkHelper.IsInternal(testUrl3, testRootUrl);

            // assert  
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }
    }
}
