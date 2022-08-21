using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = "12345", Title = "Sefiller", Author = "Victor Hugo" };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo(book);//kullanıcı kitap bilgilerinde 
            //bir değişiklik yapmadan yedek oluşturuluyor.
            //değişiklik yapılıyor.
            book.Isbn = "54321";
            book.Title = "VICTOR HUGO";
            book.ShowBook();
            //değişiklik yapıldı ama kullanıcı eski bilgileri geri istiyor.
            book.RestoreFromUndo(history.Memento);//kullanıcının yeni bilgileri eski
            //bilgilerine dönüştü
            book.ShowBook();//ve tekrardan gösterildi.
            Console.ReadLine();
        }
    }
    class Book
    {
        private string _isbn;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get { return _isbn; } set { _isbn = value; SetLastEdited(); } }
        private DateTime _lastEdited;
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo(Book book) //hafızaya alındı.
        {
            return new Memento(book, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento) //hafızadaki bilgiler aktarılıyor.
        {
            Title = memento.Title;
            Author = memento.Author;
            Isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook() //isteğe bağlı
        {
            Console.WriteLine("{0},{1},{2} edited: {3}", Isbn, Title, Author, _lastEdited);
        }
    }
    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(Book book, DateTime lastEdited)
        {
            Isbn = book.Isbn;
            Title = book.Title;
            Author = book.Author;
            LastEdited = lastEdited;
        }
    }
    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
