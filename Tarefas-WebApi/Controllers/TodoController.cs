using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    //Banco de dados em memória
    private static readonly List<Todo> todos = new List<Todo>();

    //Get -> api/todo
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(todos);
    }

    //Get -> api/todo/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    //Post -> api/todo
    [HttpPost]
    public IActionResult Create([FromBody] Todo newTodo)
    {
        todos.Add(newTodo);
        return CreatedAtAction(nameof(GetById), new { id = newTodo.Id }, newTodo);
    }

    //Put -> api/todo/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Todo updatedTodo)
    {
        var existingTodo = todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }
        existingTodo.Title = updatedTodo.Title;
        existingTodo.IsCompleted = updatedTodo.IsCompleted;
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] Todo updatedFields)
    {
        var existingTodo = todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }
        if (!string.IsNullOrEmpty(updatedFields.Title))
        {
            existingTodo.Title = updatedFields.Title;
        }
        existingTodo.IsCompleted = updatedFields.IsCompleted;
        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    public IActionResult MarkAsCompleted(int id)
    {
        var existingTodo = todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }
        existingTodo.IsCompleted = true;
        return NoContent();
    }

    //Delete -> api/todo/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        todos.Remove(todo);
        return NoContent();
    }

    //Get -> api/todo/imagem
    [HttpGet("imagem")]
    public IActionResult GetImage()
    {
        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/el2a0.jpg");

        var imagem = System.IO.File.ReadAllBytes(caminho);
        return File(imagem, "image/jpg");
    }

}

