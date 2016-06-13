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
            var db = new PhoneBookContext();
            db.People.Add(abonent);
            db.SaveChanges();
        }

        public void DeleteAbonent(Abonent abonent)
        {
            DeleteAbonent(abonent.Id);
        }

        public void DeleteAbonent(int abonentId)
        {
            var db = new PhoneBookContext();
            var abonent = db.People.SingleOrDefault(p => p.Id == abonentId);
            if (abonent != null)
            {
                db.People.Remove(abonent);
                db.SaveChanges();
            }
        }

        public void ModifyAbonent(int abonentId, Abonent abonent)
        {
            var db = new PhoneBookContext();
            var oldAbonent = db.People.Single(p => p.Id == abonentId);
            oldAbonent.Name = abonent.Name;
            oldAbonent.phoneNumber = abonent.phoneNumber;
            oldAbonent.Category = abonent.Category;
            oldAbonent.City = abonent.City;
            db.SaveChanges();
        }

        public IEnumerable<Abonent> GetPeople()
        {
            var db = new PhoneBookContext();
            return db.People.Include("Category").Include("City");   
        }

        public IEnumerable<Abonent> SearchAbonent(string s)
        {
            var db = new PhoneBookContext();
            if (s != null)
            {
                foreach (var c in s)
                {
                    //Если введены буквы, то поиск производится по имени абонента. 
                    if (char.IsLetter(c))
                    {
                        var q = db.People.Where(p => p.Name.Contains(s)).Include("Category").Include("City");
                        return q;
                    }
                    //Если введены цифры, то поиск производится по номеру абонента.
                    else if (char.IsDigit(c))
                    {
                        var number = int.Parse(s);
                        var q = db.People.Where(p => p.phoneNumber.Equals(number)).Include("Category").Include("City");
                        return q;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать поисковый запрос!");
                        break;
                    }
                }
            }
            return GetPeople();
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
