using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class HashLogger:ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable? BeginScope<Tstate>(Tstate state)where Tstate: notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            
            return true;
        }

        public void Log<Tstate>(LogLevel logLevel, EventId eventId, Tstate state, Exception?exception, Func<Tstate, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            _logMessages[eventId.Id] = message;
            switch(logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor=ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            if (_logMessages.TryGetValue(eventId.Id, out var logMessage))
            {
                Console.WriteLine("- LOGGER -");
                var messageToBeLogged = new StringBuilder();
                messageToBeLogged.Append($"[{logLevel}]");
                messageToBeLogged.AppendFormat(" [{0}] - Event ID: {1}, Message: {2}", _name, eventId.Id, logMessage);
                Console.WriteLine(messageToBeLogged);
                Console.WriteLine("- LOGGER -");
            }

            Console.ResetColor();
        }
        public bool RemoveLogMessage(int eventId)
        {
            return _logMessages.TryRemove(eventId, out _);
        }

        public void PrintAllMessages()
        {
            Console.WriteLine("- ALL LOGGER MESSAGES -");
            foreach (var logMessage in _logMessages)
            {
                Console.WriteLine($"Event ID: {logMessage.Key}, Message: {logMessage.Value}");
            }
            Console.WriteLine("- END OF LOGGER MESSAGES -");
        }
    }

}
