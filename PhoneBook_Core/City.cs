using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Core
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}