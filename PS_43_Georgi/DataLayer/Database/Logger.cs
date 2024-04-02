using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class Logger
    {
        private readonly DatabaseContext _context;

        public Logger(DatabaseContext context)
        {
            _context = context;
        }

        public void Log(string message, string logLevel = "SUCCESFUL") 
        {
            if (string.IsNullOrWhiteSpace(logLevel))
            {
                logLevel = "SUCCESFUL"; 
            }

            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Message = message,
                LogLevel = logLevel
            };

            _context.LogEntries.Add(logEntry);
            _context.SaveChanges();
        }
    }
}