using Internet_shop.Domain.Models.UserData;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdateAddress;

public class UpdateAddressCommand : IRequest
{
    public Guid UserId { get; set; }
    public UserAddress Address { get; set; }
}
