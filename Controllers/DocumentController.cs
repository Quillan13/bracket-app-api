using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BracketApp.Api.Controllers
{
    public class DocumentController : ControllerBase
    {
        protected string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
