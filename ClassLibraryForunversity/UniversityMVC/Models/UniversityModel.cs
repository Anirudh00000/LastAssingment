using System.ComponentModel.DataAnnotations;

namespace UniversityMVC.Models
{
    public class UniversityModel
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
    

