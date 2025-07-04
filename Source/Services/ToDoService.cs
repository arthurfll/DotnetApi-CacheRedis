using Source.Models;
using Source.Repositories;

namespace Source.Services;

public class ToDoService
{
  private readonly ToDoRepository _r;
  public ToDoService(ToDoRepository r)
  {
    _r = r;
  }

  public async Task<List<ToDo>> GetAllToDos()
  {
    List<ToDo> toDoList = await _r.GetAllToDos();
    return toDoList;
  }
  public async Task<ToDo> CreateNewToDo(ToDo obj)
  {
    ToDo data =  await _r.CreateNewToDo(obj);
    return data;
  }
}

