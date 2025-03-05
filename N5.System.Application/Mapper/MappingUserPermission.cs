using AutoMapper;
using N5.System.Application.UserPermission.Commands;
using N5.System.Domain.DTOs;

namespace N5.System.Application.Mapper;

internal class MappingUserPermission : Profile
{
    public MappingUserPermission()
    {
        CreateMap<Domain.Entities.UserPermission, UpdateUserPermissionCommand>().ReverseMap();
        CreateMap<Domain.Entities.UserPermission, CreateUserPermissionCommand>().ReverseMap();
        CreateMap<Domain.Entities.UserPermission, GetUserPermissionDto>().ReverseMap();
    }
}