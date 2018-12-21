using System;
using System.ComponentModel.DataAnnotations;

namespace LabFlow.Application.ViewModels
{

    public class FootballViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Loss { get; set; }
    }
}
