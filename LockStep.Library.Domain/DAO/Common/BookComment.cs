using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Library.Domain
{
    public class BookComment
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public Book Book { get; set; }
        public string Description { get; set; }
        public BookVote BookVote { get; set; }
    }
}
