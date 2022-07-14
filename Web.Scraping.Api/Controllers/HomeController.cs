using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Scraping.Api.Controllers;

public class HomeController : BaseApiController
{
    [Authorize]
    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Works");
    }
}