using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabFlow.Application.ViewModels
{
    public class TigerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
