using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController() : ApiController
{
    [HttpGet]
    public ActionResult ListDinners() 
        => Ok(Array.Empty<string>());
}
