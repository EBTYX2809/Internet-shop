using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdatePassword;

public class UpdatePasswordCommand : IRequest
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
}
