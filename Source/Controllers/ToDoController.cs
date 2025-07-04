using Microsoft.AspNetCore.Mvc;
using Source.Models;
using Source.Services;

namespace Source.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ToDoController : ControllerBase
{
  private readonly ToDoService _s;
  public ToDoController(ToDoService s)
  {
    _s = s;
  }

  [HttpGet("List")]
  public async Task<IActionResult> List()
  {
    var toDoList = await _s.GetAllToDos();
    return Ok(toDoList);
  }


  [HttpPost("New")]
  public async Task<IActionResult> Create(ToDo obj)
  {
    ToDo data = await _s.CreateNewToDo(obj);
    return Ok();
  }
}



