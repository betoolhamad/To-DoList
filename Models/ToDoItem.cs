using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models;

public class ToDoItem
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "الوصف مطلوب")] // حقل إلزامي
    public string Description { get; set; }

    
}

