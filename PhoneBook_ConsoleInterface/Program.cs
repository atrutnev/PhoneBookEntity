using PhoneBook_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBook_ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PhoneBookService();
            //service.DeleteDb();
            while (true)
            {
                //Шапка
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\t\tПростой консольный справочник на C#");
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\t\tКоличество абонентов в справочнике - {0}", service.GetPeopleSort().Count());
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
                service.ListAbonentsSort();
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("Команды меню: ");
                Console.WriteLine("1.Создать запись\n2.Удалить запись\n3.Изменить запись\n4.Поиск\n5.Очистить справочник\n6.Выход");
                Console.WriteLine((new string('=', 79)));
                Console.Write("Введите команду: ");
                Console.ForegroundColor = ConsoleColor.White;
                
                string com = Console.ReadLine();


                //Команды меню
                switch (com)
                {
                    //Создать запись
                    case "1":
                        Console.WriteLine("Введите имя: ");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Введите номер: ");
                        int phoneNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите группу: ");
                        var category = new Category { Name = Console.ReadLine() };
                        Console.WriteLine("Введите город: ");
                        var city = new City { Name = Console.ReadLine() };
                        service.AddAbonent(new Abonent{ Name = Name, phoneNumber = phoneNumber, Category = category, City = city } );
                        break;

                    //Удалить запись
                    case "2":
                        Console.WriteLine("Введите Id абонета: ");
                        int abonentId = int.Parse(Console.ReadLine());
                        service.DeleteAbonent(abonentId);
                        break;

                    //Изменить запись
                    case "3":
                        Console.WriteLine("Введите Id абонета: ");
                        int Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите имя: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Введите номер: ");
                        int newPhoneNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите группу: ");
                        var newCategory = new Category { Name = Console.ReadLine() };
                        Console.WriteLine("Введите город: ");
                        var newCity = new City { Name = Console.ReadLine() };
                        service.ModifyAbonent(Id, new Abonent { Name = newName, phoneNumber = newPhoneNumber, Category = newCategory, City = newCity });
                        break;

                    //Поиск
                    case "4":
                        Console.WriteLine("Введите часть имени абонента или номер: ");
                        string s = Console.ReadLine();                      
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine((new string('=', 79)));
                        Console.WriteLine("\t\tПростой консольный справочник на C#");
                        Console.WriteLine((new string('=', 79)));
                        Console.WriteLine("\n");
                        Console.WriteLine("Результаты поиска:\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var abonent in service.SearchAbonent(s))
                        {
                            Console.WriteLine(abonent);
                        }
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Для возврата к основному меню нажмите любую клавишу...");
                        Console.ReadKey();
                        break;

                    //Очистить справочник
                    case "5":
                        service.DeleteDb();
                        break;

                    //Выход
                    case "6":
                        return;
                        default:
                        Console.WriteLine("Недопустимая команда.\n");
                        break;
                }
            }
        }
    }
}
