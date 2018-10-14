using System;
using Microsoft.AspNetCore.Identity;

namespace ENarudzbenice2.Domain.Entities.App
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
