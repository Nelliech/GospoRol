namespace GospoRol.Domain.Models
{
    public class BaseEntity : BaseClass
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}