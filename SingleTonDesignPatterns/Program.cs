using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleTon();
            customerManager.Save();
        }
    }
    class CustomerManager
    {
        static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleTon()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
