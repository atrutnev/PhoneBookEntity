using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Core
{
    internal class PhoneBookContext : DbContext
    {
        public DbSet<Abonent> People { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}
