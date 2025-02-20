using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoEntity>> GetAllAsync();
    Task<TodoEntity?> GetByIdAsync(Guid id);
    Task<TodoEntity> CreateAsync(TodoEntity entity);
    Task<TodoEntity> UpdateAsync(TodoEntity entity);
    Task<bool> DeleteAsync(Guid id);
}
