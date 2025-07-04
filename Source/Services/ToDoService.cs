using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Source.Models;
using Source.Repositories;
namespace Source.Services;



public class ToDoService
{
  private readonly ToDoRepository _r;
  private readonly IDistributedCache _cache;
  public ToDoService(ToDoRepository r, IDistributedCache cache)
  {
    _r = r;
    _cache = cache;
  }

  public async Task<List<ToDo>> GetAllToDos()
  {
    List<ToDo> toDoList = new List<ToDo>();
    var cachedToDoList = _cache.GetString("ToDoList");

    if (!string.IsNullOrEmpty(cachedToDoList))
    {
      toDoList = JsonConvert.DeserializeObject<List<ToDo>>(cachedToDoList);
      Console.WriteLine("============ Cache Recuperado ==============");
    }
    else
    {
      toDoList = await _r.GetAllToDos();
      _cache.SetString("ToDoList", JsonConvert.SerializeObject(toDoList));
      Console.WriteLine("============ Cache Salvo ==============");
    }
    return toDoList;
  }

  public async Task<ToDo> CreateNewToDo(ToDo obj)
  {
    ToDo data = await _r.CreateNewToDo(obj);
    _cache.Remove("ToDoList");
    return data;
  }
}

