using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AMAN.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AMANUser class
public class AMANUser : IdentityUser
{

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string MobileNo { get; set; }  // change int → string
}

