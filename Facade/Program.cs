using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }
    interface ICaching
    {
        void Cache();
    }
    interface IAuthorize
    {
        void CheckUser();
    }
    interface IValidate
    {
        void Validate();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }
    class Authorize: IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }
    
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }
    class CustomerManager
    {
        private CrossCuttongCornersFacade _corners;
        public CustomerManager()
        {
            _corners = new CrossCuttongCornersFacade();
        }
        public void Save()
        {
            _corners.Logging.Log();
            _corners.Caching.Cache();
            _corners.Authorize.CheckUser();
            _corners.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }
    class CrossCuttongCornersFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;
        public CrossCuttongCornersFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
