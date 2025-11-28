using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Common.Model;

namespace UserManagement.Api.Common
{
    public static class ResponseExtension
    {
        public static ActionResult ToActionResult<TValue>(this Result<TValue> result, ControllerBase controller) where TValue : class
        {
            var response = new Response<TValue>(result);
            if (result.HasError)
            {               
                return controller.BadRequest(response);
            }
            return controller.Ok(response);

        }
    }
}
