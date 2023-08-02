using Entity.Models;

namespace NLayer.Core
{
    public class AppRole : BaseEntity
    {
        //public int Id { get; set; }
        public string? Definition { get; set; }

        public List<AppUser>? AppUsers { get; set; }
    }
}
