namespace Todo.Domain.Entities;

public sealed class TodoEntity
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; } = false;
}
