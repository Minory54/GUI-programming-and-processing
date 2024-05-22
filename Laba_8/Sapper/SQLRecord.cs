using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper
{
    public class UserRecord
    {
        public UserRecord() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Date {  get; set; }
    }

    internal class SQLRecord
    {
    }
}
