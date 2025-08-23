using Application.InfrastructureServices;
using Core.Events;
using Domain.UserAggregate.Abstracts;
using MediatR;

namespace Application.Commands.UserAggregate.DeleteUser
{
    internal class DeleteUserHandler(IUserAccessor userAccessor,IPublisher publisher, IUserRepository userRepository) : IRequestHandler<DeleteUserDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(DeleteUserDto request, CancellationToken cancellationToken)
        {
            _userRepository.Delete(_userAccessor.User);
            await _publisher.Publish( new UserDeletedEvent(_userAccessor.User.Id), cancellationToken);
        }
    }
}
