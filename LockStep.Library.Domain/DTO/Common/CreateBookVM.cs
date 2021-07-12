using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Library.Domain.DTO.Common
{
    public class CreateBookVM
    {
        [Required]
        [Display(Name="Наименование")]
        public string Name { get; set; }

    }
}
