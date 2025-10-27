namespace TodoApp.Mvc.Models.TodosViewModels
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string OwnerId { get; set; }

        public DateTimeOffset DueAt { get; set; }

        public bool IsDone { get; set; }
    }
}
