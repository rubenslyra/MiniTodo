namespace MiniTodo.Models;

public record Todo(
    int Id,
    string Title,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt = null,
    DateTime? DeletedAt = null    
);