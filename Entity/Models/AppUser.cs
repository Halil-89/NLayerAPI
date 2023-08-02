

using NLayer.Core;

namespace Entity.Models
{

    public class AppUser : BaseEntity
    {
        //public int Id { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }

        public int AppRoleId { get; set; }

        public AppRole? AppRole { get; set; }
    }
}
