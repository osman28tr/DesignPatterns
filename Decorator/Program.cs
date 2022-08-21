using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Concrete: {0}", personelCar.HirePrice);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);
            
            Console.ReadLine();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; } //kiralama ücreti
    }
    abstract class CarDecoratorBase : CarBase /*bu decorator class'ı sadece
     özelleştirmek istenilen araba türünü istemek için var bunun dışında ihtiyaca 
        göre istediğin decorator da oluşturabilirsin.
        bu şekilde kullanılan tasarım desenini kullanmadan gidip personelcar classına
        özelleştirme yapanlar var bu yanlışlığı kapatmak için bu tasarım deseni kullanılır.*/
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    class SpecialOffer : CarDecoratorBase /*burada da istediğimizi araba
     türünü(personel,commercial vs.) alıp ilgili özelleştirmemizi yaptık*/
    //buradaki özelleştirme fiyat indirimi için var.
    //DiscountPercentage propunu dışarıdan indirim oranı alıp ilgili
    //indirimi yapabilmemiz için tanımladık.
    {
        private readonly CarBase _carBase;
        public int DiscountPercentage { get; set; } //indirim oranı
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice- _carBase.HirePrice * DiscountPercentage / 100; }set { } }
    }
}
