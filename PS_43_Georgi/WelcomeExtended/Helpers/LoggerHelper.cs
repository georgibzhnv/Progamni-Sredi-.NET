using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Helpers
{
    public static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new Loggers.LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);

        }
    }
}
