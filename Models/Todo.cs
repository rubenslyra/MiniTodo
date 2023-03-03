namespace MiniTodo.Models;

public record Todo(
    Guid Id,
    string Title,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt = null,
    DateTime? DeletedAt = null
);
