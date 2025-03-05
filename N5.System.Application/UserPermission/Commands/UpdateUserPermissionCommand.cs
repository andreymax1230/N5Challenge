using MediatR;
using N5.System.Application.Mapper;
using N5.System.Application.Model;
using N5.System.Domain.DTOs;
using N5.System.Domain.Repositories;
using N5.System.Domain.UnitOfWork;

namespace N5.System.Application.UserPermission.Commands;

public class UpdateUserPermissionCommand : EventBaseHandler, IRequest<ResponseUpdateUserPermissionDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PermissionTypeId { get; set; }

    public required DateTime DatePermission { get; set; }
}

public class UpdateUserPermissionCommandHandler(IRepository<Domain.Entities.UserPermission> userPermissionRepository,
                                                IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserPermissionCommand, ResponseUpdateUserPermissionDto>
{
    public async Task<ResponseUpdateUserPermissionDto> Handle(UpdateUserPermissionCommand request, CancellationToken cancellationToken)
    {
        ResponseUpdateUserPermissionDto response = new ResponseUpdateUserPermissionDto()
        {
            EventId = request.EventId
        };
        try
        {
            var entity = MapperConfig.Mapper.Map<Domain.Entities.UserPermission>(request);
            if (entity is null)
                throw new ApplicationException("There is a problem in mapper");
            userPermissionRepository.Update(entity);
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