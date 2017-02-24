using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
    public class LoggingConfig
    {
        public LoggingConfig()
        {
            LoggingConfiguration config = new LoggingConfiguration();
            FileTarget fileTarget = new FileTarget();
            config.AddTarget("fileLogger", fileTarget);
            fileTarget.FileName = "${basedir}/log.txt";
            fileTarget.Layout = @"${date:format=HH\:mm\:ss} ${message}";
            var rule1 = new LoggingRule("*", NLog.LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule1);

            FileTarget fileTarget1 = new FileTarget();
            config.AddTarget("threadLogger", fileTarget1);
            fileTarget1.FileName = "${basedir}/threadLog.txt";
            fileTarget1.Layout = @"${date:format=HH\:mm\:ss} ${message}";
            var rule2 = new LoggingRule("*", NLog.LogLevel.Debug, fileTarget1);
            config.LoggingRules.Add(rule2);

            LogManager.Configuration = config;
        }
    }
}
