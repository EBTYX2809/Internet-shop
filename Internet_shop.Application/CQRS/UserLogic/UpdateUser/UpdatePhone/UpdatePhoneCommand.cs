using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdatePhone;

public class UpdatePhoneCommand : IRequest
{
    public Guid UserId { get; set; }
    public string Phone { get; set; }
}
