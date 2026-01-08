using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.CreateUser;

public class CreateGuestCustomerCommand : IRequest<Guid> { }
