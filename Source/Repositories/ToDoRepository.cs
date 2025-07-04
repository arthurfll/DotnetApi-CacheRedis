using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Source.Data;
using Source.Models;

namespace Source.Repositories;

public class ToDoRepository
{
  private readonly AppDbContext _db;
  
  public ToDoRepository(AppDbContext db)
  {
    
    _db = db;
  }

  public async Task<List<ToDo>> GetAllToDos()
  {
    List<ToDo> toDoList = await _db.ToDos.ToListAsync();
    return toDoList;
  }

  public async Task<ToDo> CreateNewToDo(ToDo obj)
  {
    try
    {
      await _db.ToDos.AddAsync(obj);
      await _db.SaveChangesAsync();
      return obj;
    }
    catch (System.Exception)
    {
      
      throw;
    }

  }
}

