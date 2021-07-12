using System.ComponentModel.DataAnnotations;

namespace LockStep.Library.Domain
{
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public Author Author{ get; set; }
    }
}
