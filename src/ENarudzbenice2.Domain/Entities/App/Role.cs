using System;
using System.Collections.Generic;
using DDFramework;
using Microsoft.AspNetCore.Identity;

namespace ENarudzbenice2.Domain.Entities.App
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
