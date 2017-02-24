﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WebPageParser.ServiceHost
{
    class Program
    {
      
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<PageParserService>(s =>                        
                {
                    s.ConstructUsing(name => new PageParserService());     
                    s.WhenStarted(tc => tc.Start());              
                    s.WhenStopped(tc => tc.Stop());               
                });
                x.StartAutomatically();
                x.RunAsLocalSystem();
                

                x.SetDescription("WebPageParser service host");        
                x.SetDisplayName("WebPageParserServiceHost");                       
                x.SetServiceName("WebPageParserServiceHost");                       
            });                                                  
        }
    }
}