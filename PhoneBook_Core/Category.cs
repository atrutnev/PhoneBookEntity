using System.Collections.Generic;

namespace PhoneBook_Core
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}