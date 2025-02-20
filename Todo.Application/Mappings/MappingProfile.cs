using AutoMapper;
using Todo.Application.Dtos;
using Todo.Domain.Entities;

namespace Todo.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TodoEntity, TodoDto>().ReverseMap();
    }
}
