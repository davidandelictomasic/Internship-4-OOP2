using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Common;
using UserManagement.Application.Users.User;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserUnitOfWork unitOfWork)
        {
        
            var requestHandler = new GetAllUsersRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessActiveRequestAsnync(new GetAllUsersRequest());
            return result.ToActionResult(this);

            
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromServices] IUserUnitOfWork unitOfWork, [FromRoute] int id)
        {

            var requestHandler = new GetByIdUserRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessActiveRequestAsnync(new GetByIdUserRequest(id));
            return result.ToActionResult(this);


        }
        [HttpPost]
        public async Task<ActionResult> Post(
            [FromServices] IUserUnitOfWork unitOfWork,
            [FromBody] CreateUserRequest request

            )
        {
            var requestHandler = new CreateUserRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessActiveRequestAsnync(request);
            return result.ToActionResult(this);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            [FromServices] IUserUnitOfWork unitOfWork,
            [FromRoute] int id,
            [FromBody] UpdateUserRequest request

            )
        {
            var requestHandler = new UpdateUserRequestHandler(unitOfWork);
            requestHandler.SetUserId(id);
            var result = await requestHandler.ProcessActiveRequestAsnync(request);
            return result.ToActionResult(this);
        }


    }
}
