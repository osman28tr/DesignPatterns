using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager osman = new Manager { Name = "osman", Salary = 5000 };
            Manager hamza = new Manager { Name = "hamza", Salary = 5000 };

            Worker ela = new Worker { Name = "ela", Salary = 4000 };
            Worker eymen = new Worker { Name = "eymen", Salary = 4000 };

            osman.Subordinates.Add(hamza);
            hamza.Subordinates.Add(ela);
            hamza.Subordinates.Add(eymen);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(osman);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payrise = new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);
            Console.ReadLine();
        }
    }
    class OrganisationalStructure // kurum yapısı
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase //örn:personeller için zamlanmış maaş kısmını yapar.
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayrollVisitor : VisitorBase //maaş ödemesi
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }
    class PayriseVisitor : VisitorBase //maaş artışı
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
}
