using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForunversity.Model
{
    public class University
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? UniversityName { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? AffiliatedUnder { get; set; }
        [Required]
        public int? EstablishedYear { get; set; }

    }
}
