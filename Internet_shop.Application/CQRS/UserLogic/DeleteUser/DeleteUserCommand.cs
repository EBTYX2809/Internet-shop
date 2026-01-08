using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid UserId { get; set; }
}
