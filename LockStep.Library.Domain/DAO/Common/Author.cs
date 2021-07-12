using System.ComponentModel.DataAnnotations;

namespace LockStep.Library.Domain
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}