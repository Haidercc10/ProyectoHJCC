using Microsoft.AspNetCore.Identity;

namespace Proyecto.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
