using System.ComponentModel.DataAnnotations;

public class ToDos
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public DateTime Created { get; set; }
    public bool IsDone { get; set; }
}