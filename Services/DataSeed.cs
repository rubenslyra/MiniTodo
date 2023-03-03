using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniTodo.Data;
using MiniTodo.Models;

namespace MiniTodo.Services
{
    public class DataSeed
    {
        private readonly AppDbContext _context;

        public DataSeed(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Todos.Any())
                return;

            var todos = new List<Todo>();
            for (int i = 0; i < 10; i++)
            {
                todos.Add(new Todo(
                    Guid.NewGuid(),
                    $"Todo {i}",
                    false,
                    DateTime.Now
                ));
            }

            _context.Todos.AddRange(todos);
            _context.SaveChanges();
        }

    }
}