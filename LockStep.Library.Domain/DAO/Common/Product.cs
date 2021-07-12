using System.ComponentModel.DataAnnotations;

namespace LockStep.Library.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
    }
}
