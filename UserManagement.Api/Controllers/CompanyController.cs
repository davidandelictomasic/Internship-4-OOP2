using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Common;
using UserManagement.Application.Users.Companies;
using UserManagement.Application.Users.User;
using UserManagement.Domain.Persistence.Companies;

namespace UserManagement.Api.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll(string username,string password,[FromServices] ICompanyUnitOfWork unitOfWork)
        {

            var requestHandler = new GetAllCompaniesRequestHandler(unitOfWork);
            requestHandler.SetUserData(username, password);
            var result = await requestHandler.ProcessActiveRequestAsnync(new GetAllCompaniesRequest());
            return result.ToActionResult(this);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string username, string password,[FromServices] ICompanyUnitOfWork unitOfWork, [FromRoute] int id)
        {
            var requestHandler = new GetByIdCompanyRequestHandler(unitOfWork);            
            requestHandler.SetUserData(username, password);
            var result = await requestHandler.ProcessActiveRequestAsnync(new GetByIdCompanyRequest(id));
            return result.ToActionResult(this); ;



        }
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] ICompanyUnitOfWork unitOfWork,[FromBody] CreateCompanyRequest request)
        {
            var requestHandler = new CreateCompanyRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessActiveRequestAsnync(request);
            return result.ToActionResult(this);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            [FromServices] ICompanyUnitOfWork unitOfWork,
            [FromRoute] int id,
            [FromBody] UpdateCompanyRequest request

            )
        {
            var requestHandler = new UpdateCompanyRequestHandler(unitOfWork);
            requestHandler.SetCompanyId(id);
            var result = await requestHandler.ProcessActiveRequestAsnync(request);
            return result.ToActionResult(this);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteById(string username, string password ,int id, [FromServices] ICompanyUnitOfWork unitOfWork)
        {
            var requestHandler = new DeleteCompanyRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessActiveRequestAsnync(new DeleteCompanyRequest(id,username,password));
            return result.ToActionResult(this);



        }
    }
}
