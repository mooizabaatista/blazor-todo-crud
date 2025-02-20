using AutoMapper;
using System.Linq.Expressions;
using Todo.Application.Dtos;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public TodoService(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<List<TodoDto>> GetAllAsync()
    {
        try
        {
            var response = await _todoRepository.GetAllAsync();
            var todosDto = _mapper.Map<List<TodoDto>>(response);
            return todosDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoDto> GetByIdAsync(Guid id)
    {
        try
        {
            var response = await _todoRepository.GetByIdAsync(id);
            var todoDto = _mapper.Map<TodoDto>(response);
            return todoDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoDto> CreateAsync(TodoDto dto)
    {
        try
        {
            var todoEntity = _mapper.Map<TodoEntity>(dto);
            var response = await _todoRepository.CreateAsync(todoEntity);
            return _mapper.Map<TodoDto>(response);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TodoDto> UpdateAsync(TodoDto dto)
    {
        try
        {
            var todoEntity = _mapper.Map<TodoEntity>(dto);
            var response = await _todoRepository.UpdateAsync(todoEntity);
            return _mapper.Map<TodoDto>(response);

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
            return await _todoRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
