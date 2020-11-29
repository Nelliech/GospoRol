
using System.Collections.Generic;
using GospoRol.Domain.Models.Places;
using Microsoft.AspNetCore.Identity;

namespace GospoRol.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Land> Lands { get; set; }
    }
}