using Microsoft.AspNetCore.Mvc;
using TodoApp.Mvc.Models.TodosViewModels;

namespace TodoApp.Mvc.Controllers
{
    public class TodosController : Controller
    {
        // In-memory list of TodoItems for demonstration purposes
        public static List<TodoItem> _todoItems = new()
        {
            new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "ASP.NET Training",
                OwnerId = "user1",
                DueAt = DateTimeOffset.Now.AddDays(2),
                IsDone = false
            },
            new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = "ASP.NET Assignment",
                OwnerId = "user2",
                DueAt = DateTimeOffset.Now.AddDays(2),
                IsDone = true
            }
        };

        public IActionResult Index()
        {
            TodoViewModel vm = new TodoViewModel
            {
                TodoItems = _todoItems
            };

            return View(vm);
        }

        public IActionResult ViewItem(Guid id)
        {
            TodoItem? item = _todoItems
                .Where(i => i.Id == id)
                .SingleOrDefault();
                
            return View(item);
        }

        public IActionResult EditItem(Guid id)
        {
            TodoItem? item = _todoItems
                .Where(i => i.Id == id)
                .SingleOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdateItem(TodoItem todo)
        {
            var item = _todoItems.SingleOrDefault(i => i.Id == todo.Id);

            if (item == null) return NotFound();

            item.Title = todo.Title;
            item.DueAt = todo.DueAt;
            item.IsDone = todo.IsDone;
            item.OwnerId = todo.OwnerId;

            return View("EditItem", todo);
        }
    }
}
