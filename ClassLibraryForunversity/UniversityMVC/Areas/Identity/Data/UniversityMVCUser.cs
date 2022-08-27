using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UniversityMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UniversityMVCUser class
public class UniversityMVCUser : IdentityUser
{
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
    public string? PanNo { get; set; }
}

