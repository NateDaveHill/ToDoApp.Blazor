using System.ComponentModel.DataAnnotations;

public class ToDos
{
    public int Id { get; set; }
    [MaxLength (50)]
    public string? Title { get; set; }
    [MaxLength (50)]
    public string? Comment { get; set; }
    public DateTime Created { get; set; }
    public bool IsDone { get; set; }
}