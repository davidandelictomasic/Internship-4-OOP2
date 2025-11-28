

using UserManagement.Domain.Entities.Companies;

namespace UserManagement.Application.DTOs.Companies
{
    public class CompanyDto
    {

        public string Name { get; set; }
        

        public static CompanyDto FromEntity(Company c)
        {
            return new CompanyDto
            {

                Name = c.Name
               
            };
        }
    }
}
