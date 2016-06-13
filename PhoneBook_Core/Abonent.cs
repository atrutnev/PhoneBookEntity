using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Core
{
    public class Abonent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int phoneNumber { get; set; }

        public Category Category { get; set; }

        public City City { get; set; }

        public override string ToString()
        {
            return String.Format("\tАбонент: {1} - {2} [ Id: {0}, Группа: {3}, Город: {4} ]", Id, Name, phoneNumber, Category.Name, City.Name);
        }
    }
}
