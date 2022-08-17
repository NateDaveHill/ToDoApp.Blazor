using System.ComponentModel.DataAnnotations;

public class ToDos
{
    public int Id { get; set; }
    public string? Title { get; set; }
    //[MaxLength (5)]
    public string? Comment { get; set; }

    //[MaxLength(5)]
    public DateTime Created { get; set; }
    public bool IsDone { get; set; }
}