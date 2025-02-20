using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;

namespace Todo.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task<List<TodoEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Todos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            var todo = await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return todo;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoEntity> CreateAsync(TodoEntity entity)
    {
        try
        {
            var todoCreated = await _context.Todos.AddAsync(entity);
            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return todoCreated.Entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoEntity> UpdateAsync(TodoEntity entity)
    {
        try
        {           
            var todoUpdated = _context.Todos.Update(entity);
            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return todoUpdated.Entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var entityExists = await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entityExists == null)
                return false;

            var response = _context.Todos.Remove(entityExists);
            await _context.SaveChangesAsync();

            if (response.Entity == null)
                return false;
            else
                return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
