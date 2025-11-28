using UserManagement.Domain.Abstractions;

namespace UserManagement.Domain.Entities.Companies
{
    public class Company : Entity
    {
        public const int NameMaxLength = 150;
        public string Name { get; private set; }

        public async Task Create()
        {


        }
        public async Task CreateOrUpdateValidation()
        {

        }
    }
}
