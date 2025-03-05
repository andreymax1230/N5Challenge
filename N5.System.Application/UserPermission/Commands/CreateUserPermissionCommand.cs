using MediatR;
using N5.System.Application.Mapper;
using N5.System.Application.Model;
using N5.System.Domain.DTOs;
using N5.System.Domain.Repositories;
using N5.System.Domain.UnitOfWork;

namespace N5.System.Application.UserPermission.Commands;


public class CreateUserPermissionCommand : EventBaseHandler, IRequest<ResponseCreateUserPermissionDto>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PermissionTypeId { get; set; }

    public required DateTime DatePermission { get; set; }
}

public class CreateUserPermissionCommandHandler(IRepository<Domain.Entities.UserPermission> userPermissionRepository,
                                                IUnitOfWork unitOfWork) : IRequestHandler<CreateUserPermissionCommand, ResponseCreateUserPermissionDto>
{
    public async Task<ResponseCreateUserPermissionDto> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
    {
        ResponseCreateUserPermissionDto response = new ResponseCreateUserPermissionDto()
        {
            EventId = request.EventId
        };
        try
        {
            var entity = MapperConfig.Mapper.Map<Domain.Entities.UserPermission>(request);
            if (entity is null)
                throw new ApplicationException("There is a problem in mapper");
            userPermissionRepository.Insert(entity);
            var responseBD = await unitOfWork.CommitAsync(cancellationToken);
            if (responseBD <= 0)
                response.ErrorMessage = $"Error save entitie: {nameof(Domain.Entities.UserPermission)} in BD";
            response.Response = responseBD > 0;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
