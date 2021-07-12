using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LockStep.Library.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}