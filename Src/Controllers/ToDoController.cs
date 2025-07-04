using Microsoft.AspNetCore.Mvc;

namespace Source.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ToDoController : ControllerBase
{
  [HttpGet("List")]
  public IActionResult List()
  {
    return Ok("Hello World");
  }
}

