using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Data.Models
{
    public class EkBilgiler
    {
        [Key]
        public int EkBilgilerId { get; set; }
        // ad must be range max 100 caracter
        [MaxLength(100)]
        public string Ad { get; set; }
        [MaxLength(500)]
        public string Aciklama { get; set; }
        public int UstId { get; set; } = 0;
    }
}
