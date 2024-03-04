using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Data.Models
{
    public class Subscribe
    {
        [Key]
        public int SubscribeID { get; set; }
        public string Mail { get; set; }
    }
}
