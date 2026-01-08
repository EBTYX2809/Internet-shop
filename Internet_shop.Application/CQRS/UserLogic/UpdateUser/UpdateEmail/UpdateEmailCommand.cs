using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdateEmail;

public class UpdateEmailCommand : IRequest
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
}
