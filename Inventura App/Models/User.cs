using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Inventura_App.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(250), Unique]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
