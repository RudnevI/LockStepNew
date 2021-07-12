using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Library.Domain.Finance
{
    public class Check
    {
        [Key]
        public int Id { get; set; }
        public string IdRequest { get; set; }
        public string Email { get; set; }
        public Book Book { get; set; }
        public int Status { get; set; }
    }
}
