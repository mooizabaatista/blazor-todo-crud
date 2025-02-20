using Todo.Application.Dtos;

namespace Todo.Application.Interfaces;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllAsync();
    Task<TodoDto> GetByIdAsync(Guid id);
    Task<TodoDto> CreateAsync(TodoDto dto);
    Task<TodoDto> UpdateAsync(TodoDto dto);
    Task<bool> DeleteAsync(Guid id);
}
