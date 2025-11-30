
namespace UserManagement.Domain.Abstractions
{
    public abstract class Entity
    {
        public int Id { get; protected set; }        
        public DateTime UpdatedAt { get; set; } 

    }
}
