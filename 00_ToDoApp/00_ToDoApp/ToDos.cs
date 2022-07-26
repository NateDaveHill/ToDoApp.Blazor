using System.ComponentModel.DataAnnotations;

public class ToDos
{
    public int ToDoId { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public DateTime DateTimeAdd { get; set; }
}
