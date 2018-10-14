using System.Collections.Generic;
using DDFramework;
using ENarudzbenice2.Domain.Entities.App;
using Newtonsoft.Json;

namespace ENarudzbenice2.Domain.Entities
{
    public class Djelatnost : SifarnikEntity
    {
        public User Radnik { get; set; }

        [JsonIgnore]
        public List<Tim> Timovi { get; set; }
    }
}
