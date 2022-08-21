using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);//base'de Successor=vicePresident
            vicePresident.SetSuccessor(president);//base'de Successor=president

            Expense expense = new Expense { Detail = "Training", Amount = 110 };
            manager.HandleExpense(expense);
            Console.ReadLine();
        }
    }
    class Expense //harcama
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor; //ilgili yetkili kişinin üst seviyesini
        //belirlemek için bu Successor dışarından set edilir.
        public abstract void HandleExpense(Expense expense);//ilgili yetkili kişinin
        //expense'i handle edebileceği bir operasyon tanımladık
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
        }
    }
}
