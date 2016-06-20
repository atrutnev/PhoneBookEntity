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
        //Метод добавления абонента
        public void AddAbonent(Abonent abonent)
        {
            var db = new PhoneBookContext();
            db.People.Add(abonent);
            db.SaveChanges();
        }

        //Методы удаления абонента
        public void DeleteAbonent(Abonent abonent)
        {
            DeleteAbonent(abonent.Id);
        }

        public void DeleteAbonent(int abonentId)
        {
            var db = new PhoneBookContext();
            var abonent = db.People.SingleOrDefault(a => a.Id == abonentId);
            if (abonent != null)
            {
                db.People.Remove(abonent);
                db.SaveChanges();
            }
        }

        //Метод изменения абонента
        public void ModifyAbonent(int abonentId, Abonent abonent)
        {
            var db = new PhoneBookContext();
            var oldAbonent = db.People.Single(a => a.Id == abonentId);
            oldAbonent.Name = abonent.Name;
            oldAbonent.phoneNumber = abonent.phoneNumber;
            oldAbonent.Category = abonent.Category;
            oldAbonent.City = abonent.City;
            db.SaveChanges();
        }

        //Метод формирования списка абонентов
        public IEnumerable<Abonent> GetPeopleSort()
        {
            var db = new PhoneBookContext();
            var q = db.People.Include("Category").Include("City").OrderBy(a => a.Name);
            return q;
        }


        //Метод поиска
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
                        var q = db.People.Where(a => a.Name.Contains(s)).Include("Category").Include("City");
                        return q;
                    }
                    //Если введены цифры, то поиск производится по номеру абонента.
                    else if (char.IsDigit(c))
                    {
                        var number = int.Parse(s);
                        var q = db.People.Where(a => a.phoneNumber.Equals(number)).Include("Category").Include("City");
                        return q;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать поисковый запрос!");
                        break;
                    }
                }
            }
            return GetPeopleSort();
        }


        public Abonent GetAbonent(int id)
        {
            var db = new PhoneBookContext();
            var q = db.People.Include("Category").Include("City").Single(a => a.Id == id);
            return q;
        }

        //Метод очистки справочника (удаление БД)
        public void DeleteDb()
        {
            var db = new PhoneBookContext();
            db.Database.Delete();
        }


        //Метод вывода списка абонентов на экран
        public void ListAbonentsSort()
        {
            foreach (var a in GetPeopleSort())
            {
                Console.WriteLine(a);
            }
        }
    }
}
