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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\t\tПростой консольный справочник на C#");
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Количество абонентов в справочнике - {0}", service.GetPeople().Count());
                service.ListAbonents();
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("Команды меню: ");
                Console.WriteLine("1.Создать запись\n2.Удалить запись\n3.Изменить запись\n4.Поиск\n5.Сохранить список и выйти\n6.Выход без сохранения");
                Console.WriteLine((new string('=', 79)));
                Console.Write("Введите команду: ");
                Console.ForegroundColor = ConsoleColor.White;
                
                string com = Console.ReadLine();


                //Команды меню
                switch (com)
                {
                    case "1":
                        service.AddAbonent(new Abonent{ });
                        break;
                    case "2":
                        service.DeleteAbonent();
                        break;
                //    case "3":
                //        pb.ModifyAbonent();
                //        break;
                    case "4":
                        Console.WriteLine("Введите имя абонента: ");
                        string s = Console.ReadLine();
                        Console.WriteLine("Результаты поиска:");
                        foreach (var abonent in service.SearchAbonent(s))
                        {
                            Console.WriteLine(abonent);
                        }
                        Console.ReadKey();
                        break;
                //    case "5":
                //pb.SaveAbonentsToXml();
                //return;
                //    case "6":
                //return;
                default:
                Console.WriteLine("Недопустимая команда.\n");
                break;
                }
            }
        }
    }
}
