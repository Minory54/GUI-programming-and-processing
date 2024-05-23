using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper
{
    internal class DBEntities : DbContext
    {
        public DBEntities() : base("DefaultConnection") { }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
    }
}
