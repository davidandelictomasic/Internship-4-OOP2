
namespace UserManagement.Domain.Abstractions
{
    public abstract class Entity
    {
        public int ID { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
