using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.Models.ViewModels
{
    public class CreateTodoViewModel : Notifiable<Notification>
    {
        public string Title { get; set; }

        // Método para validar o ViewModel
        public Todo MapTo()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Title, "Title", "Título é obrigatório")
                .IsGreaterThan(Title, 5, "Title", "Título deve conter mais de 5 caracteres");

            AddNotifications(contract);

            return new Todo(Guid.NewGuid(), Title, false, DateTime.Now, null);
        }

    }
}