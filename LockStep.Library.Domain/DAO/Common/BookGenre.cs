using System.ComponentModel.DataAnnotations;

namespace LockStep.Library.Domain
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
