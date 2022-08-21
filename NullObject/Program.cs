using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }
    interface ILogger
    {
        void Log();
    }
    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with Log4NetLogger");
        }
    }
    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with NLogLogger");
        }
    }
    class StubLogger : ILogger
    {
        private static StubLogger _stublogger;
        private static object _lock = new object();
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stublogger == null)
                {
                    _stublogger = new StubLogger();
                }
            }
            return _stublogger;
        }
        private StubLogger()
        {

        }
        public void Log()
        {
            
        }
    }
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}
