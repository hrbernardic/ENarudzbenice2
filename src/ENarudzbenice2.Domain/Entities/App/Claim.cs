using DDFramework;

namespace ENarudzbenice2.Domain.Entities.App
{
    public class Claim : BaseEntity
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Active { get; set; }
    }
}
