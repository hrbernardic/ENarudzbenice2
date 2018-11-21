using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DDFramework;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace ENarudzbenice2.Domain.Entities.App
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Aktivan { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumIzrade { get; set; }
        public string PrikazIme { get; set; }


    public Tim Tim { get; set; }

        [JsonIgnore]
        public ICollection<Djelatnost> Djelatnosti { get; set; }

        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
