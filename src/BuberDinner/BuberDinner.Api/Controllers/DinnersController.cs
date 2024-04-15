using BubeerDinner.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController() : ApiController
{
    public ActionResult ListDinners() {
        return Ok(Array.Empty<string>());
    }
}
