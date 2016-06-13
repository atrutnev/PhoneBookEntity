using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Core
{
    public class PhoneBookService
    {
        
        public void AddAbonent(Abonent abonent)
        {
            Console.WriteLine("Введите имя: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите номер: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите группу: ");
            var categoryname = new Category { Name = Console.ReadLine() };
            Console.WriteLine("Введите город: ");
            var namecity = new City { Name = Console.ReadLine() };
            var db = new PhoneBookContext();
            db.People.Add(new Abonent { Name = Name, phoneNumber = phoneNumber, Category = categoryname, City = namecity  });
            db.SaveChanges();
        }

        //public void DeleteAbonent(Abonent abonent)
        //{
        //    DeleteAbonent(abonent.Id);
        //}

        public void DeleteAbonent()
        {
            Console.WriteLine("Введите Id абонета: ");
            int abonentId = int.Parse(Console.ReadLine());
            var db = new PhoneBookContext();
            var abonent = db.People.SingleOrDefault(p => p.Id == abonentId);
            if (abonent != null)
            {
                db.People.Remove(abonent);
                db.SaveChanges();
            }
        }

        public IEnumerable<Abonent> GetPeople()
        {
            var db = new PhoneBookContext();
            return db.People.Include("Category").Include("City");   
        }

        public IEnumerable<Abonent> GetPeople(string s)
        {
            var db = new PhoneBookContext();
            var q = db.People.Where(p => p.Name.Contains(s)).Include("Category").Include("City");
            return q;
        }

        public IEnumerable<Abonent> SearchAbonent(string s)
        {
            var db = new PhoneBookContext();
            var q = db.People.Where(p => p.Name.Contains(s)).Include("Category").Include("City");
            return q;

        }

        public IEnumerable<Category> GetCategories()
        {
            var db = new PhoneBookContext();
            return db.Categories.Include("People");
        }

        public void DeleteDb()
        {
            var db = new PhoneBookContext();
            db.Database.Delete();
        }

        public void ListAbonents()
        {
            foreach (var a in GetPeople())
            {
                Console.WriteLine(a);
            }
        }

    }
}
