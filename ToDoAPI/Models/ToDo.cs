using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; }

        public string? Todo { get; set; }

        public string? Done { get; set; }
    }
}
