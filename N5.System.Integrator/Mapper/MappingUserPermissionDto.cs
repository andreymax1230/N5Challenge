using AutoMapper;
using N5.System.Application.UserPermission.Commands;
using N5.System.Application.UserPermission.Queries;
using N5.System.Domain.DTOs;

namespace N5.System.Integrator.Mapper;

internal class MappingUserPermissionDTO : Profile
{
    public MappingUserPermissionDTO()
    {
        CreateMap<UpdateUserPermissionCommand, UpdateUserPermissionDto>().ReverseMap();
        CreateMap<CreateUserPermissionCommand, CreateUserPermissionDto>().ReverseMap();
        CreateMap<UserPermissionQuery, RequestGetUserPermissionDto>().ReverseMap();
    }
}