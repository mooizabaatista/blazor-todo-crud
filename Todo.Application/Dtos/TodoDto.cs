using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Todo.Application.Dtos;

public class TodoDto
{
    public Guid Id { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O campo Título é obrigatório.")]
    [MaxLength(ErrorMessage ="O campo Título deve conter no máximo 100 caracteres.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
    [MaxLength((600), ErrorMessage = "O campo Descrição deve conter no máximo 600 caracteres.")]
    public string Description { get; set; } = string.Empty;

    public bool Done { get; set; } = false;
}
