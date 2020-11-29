namespace GospoRol.Domain.Models.BaseClasses
{
    public abstract class BaseEntity : BaseClass
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}