using System;
using System.Text.RegularExpressions;

namespace WebPageParser.Helpers
{
    public class LinkHelper
    {
        private static Regex regex = new Regex(@"https?:\/\/.*");
        public static string FixUrl(string link, string rootUrl)
        {
            string result = string.Empty;
            //if (string.IsNullOrWhiteSpace(link))
            //{
            //    result = rootUrl;
            //}
            //else if (link.Length > 1 && link[0] == '/' && link[1] == '/')
            //{
            //    result = "http:" + link;
            //}

            //else if (link[0] == '/')
            //{
            //    result = rootUrl + link;
            //}

            //else if (regex.IsMatch(link))
            //{
            //    result = link;
            //}

            //else
            //{
            //    result = rootUrl + '/' + link;
            //}
            if (regex.IsMatch(link))
            {
                result = link;
            }
            else
            {
                Uri res;
                var success = Uri.TryCreate(new Uri(rootUrl), link, out res);
                if (success)
                    result = res.ToString();
                else
                    result = "Bad url";
            }
            

            return result;
        }

        public static bool IsInternal(string link, string rootUrl)
        {
            Regex regex = new Regex(@"https?:\/\/(?<root>((www.)?([\da-z\.-]+)\.([a-z\.]{2,6}))).*");
            bool result = false;
            var linkRoot = regex.Match(link).Groups["root"].Value;
            var rootUrlRoot = regex.Match(rootUrl).Groups["root"].Value;
            if (linkRoot == rootUrlRoot)
            {
                result = true;
            }
            return result;
        }
    }
}
