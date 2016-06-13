using System.Collections.Generic;

namespace PhoneBook_Core
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}