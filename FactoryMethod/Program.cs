using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new OtLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }  
    public interface ILogger
    {
        void Log();
    }
    public class OtLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with OtLogger");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
