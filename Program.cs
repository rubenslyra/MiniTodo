using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using MiniTodo.Data;
using MiniTodo.Models;
using MiniTodo.Models.ViewModels;
using MiniTodo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MiniTodo", Version = "v1" });
});

var app = builder.Build();
// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniTodo v1"));

// Mapeamento de resultados a partir do contexto de dados (AppDbContext) a partir do método MapGet (v1/todos)
app.MapGet("v1/todos", (AppDbContext contexto) =>
{
    var todos = contexto.Todos.ToList();
    return Results.Ok(todos);
}).Produces<Todo>();

app.MapPost("v1/todos/create", (AppDbContext contexto, CreateTodoViewModel modelView) =>
{
    var todo = modelView.MapTo();
    if (!modelView.IsValid)
        return Results.BadRequest(modelView.Notifications);
    contexto.Todos.Add(todo);
    contexto.SaveChanges();

    return Results.Created($"/v1/todos/{todo.Id}", todo);
});
app.Run();
