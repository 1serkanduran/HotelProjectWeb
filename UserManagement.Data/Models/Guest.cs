using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Data.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
        public string NameSurname { get; set; }
        public string City { get; set; }
    }
}
