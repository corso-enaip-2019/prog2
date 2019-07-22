using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_06_MVC.Infrastructure.Exceptions;
using System.Linq;

namespace P19_Web_Dynamic_06_MVC.Controllers
{
    public class BaseController : Controller
    {
        protected void CheckInput()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value
                        .Errors
                        .Select(y => y.ErrorMessage));

                var errorMessage = string.Join("; ", errors);

                throw new InvalidInputException(errorMessage);
            }
        }
    }
}
