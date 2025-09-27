namespace ToDoApi.Models;

public class Todo
{
    private static int _nextId = 1;

    public Todo()
    {
        Id = _nextId++;
        Title = string.Empty;
        IsCompleted = false;
        CreatedAt = DateTime.UtcNow;
    }

    public Todo(string title)
    {
        Id = _nextId++;
        Title = title;
        IsCompleted = false;
        CreatedAt = DateTime.UtcNow;
    }
    public Todo(string title, bool isCompleted, DateTime createdAt)
    {
        Id = _nextId++;
        Title = title;
        IsCompleted = isCompleted;
        CreatedAt = createdAt;
    }

    public int Id { get; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}



