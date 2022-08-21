using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee osman = new Employee();
            osman.Name = "Osman Yazilimci";
            Employee hamza = new Employee();
            hamza.Name = "Hamza Yazilimci";
            osman.AddSubordinate(hamza);
            Employee ela = new Employee();
            ela.Name = "Ela Yazilimci";
            hamza.AddSubordinate(ela);
            Console.WriteLine(osman.Name);
            foreach (Employee manager in osman)
            {
                Console.WriteLine(" "+manager.Name);

                foreach (Employee employee in manager)
                {
                    Console.WriteLine("  "+employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        void AddSubordinate(IPerson person);
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name;

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
