namespace WebPageParser.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
           PageParser pageParser = new PageParser();
            //pageParser.Parse(@"https://google.com",1 , 10, false);
            pageParser.Parse(@"https://en.wikipedia.org/wiki/Main_Page",3 , 10, false);

            //pageParser.Parse(@"https://developer.microsoft.com", 3, 10, false);
            //pageParser.Parse(@"http://www.ok-studio.com.ua/", 10, 10, false);
            //pageParser.BuildTree(@"https://en.wikipedia.org/wiki/Main_Page", "1.txt",false);
        }
    }
}
