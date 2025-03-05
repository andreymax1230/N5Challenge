using MediatR;
using N5.System.Application.Mapper;
using N5.System.Application.Model;
using N5.System.Domain.DTOs;
using N5.System.Domain.Repositories;

namespace N5.System.Application.UserPermission.Queries;

public class UserPermissionQuery : EventBaseHandler, IRequest<ResponseGetUserPermissionDto>{}

public class UserPermissionQueryHandler(IRepository<Domain.Entities.UserPermission> userPermissionRepository) : IRequestHandler<UserPermissionQuery, ResponseGetUserPermissionDto>
{
    public async Task<ResponseGetUserPermissionDto> Handle(UserPermissionQuery request, CancellationToken cancellationToken)
    {
        ResponseGetUserPermissionDto response = new ResponseGetUserPermissionDto()
        {
            EventId = request.EventId
        };
        try
        {
            var listBD = await userPermissionRepository.GetAll();
            var list = MapperConfig.Mapper.Map<List<GetUserPermissionDto>>(listBD);
            response.Response = list;
        }
        catch (global::System.Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
