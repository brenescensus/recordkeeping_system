using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AC_BM.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
       
        public string Name { get; set; }
        public string? Profilepicture { get; set; }
    }
}
