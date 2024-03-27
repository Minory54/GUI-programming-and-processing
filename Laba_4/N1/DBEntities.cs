using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace N1
{
    internal class DBEntities : DbContext //Для подключения к базе данных (DBEntities бедется из Appconfig)
    {
        public DBEntities() : base("DefaultConnection") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Journal> Journals { get; set; }
    }
}
