using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebPageParser.ServiceHost.DAL;
using WebPageParser.ServiceHost.Models;

namespace WebPageParser.ServiceHost
{

    public class PageParserService
    {
        private bool isWorking = false;
        private Timer timer = new Timer();
        private PageParser pageParser = new PageParser();
        public void Start()
        {
            timer.Interval = 2000;
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
         if(!isWorking)
            {
                isWorking = true;
                ExecuteNextCommand();
                isWorking = false;

            }   
        }

        public void Stop()
        {
            timer.Stop();
        }

        private Command GetNewCommand()
        {
            using (var context = new WebPageParserCommandContext())
            {
                Command cmd = context.Commands.OrderBy(c=>c.DateCreated).FirstOrDefault();
                return cmd;
            }
        }

        private void ExecuteNextCommand()
        {
            var cmd = GetNewCommand();
            {
                if(cmd != default(Command))
                {
                    cmd.Run(pageParser);
                    RemoveCommand(cmd);         
                }
            }
        }

        private void RemoveCommand(Command cmd)
        {
            using (var context = new WebPageParserCommandContext())
            {
                Command tempCmd = context.Commands.FirstOrDefault(c=>c.Id == cmd.Id);
                context.Commands.Remove(tempCmd);
                context.SaveChanges();
            }
        }
    }
}
