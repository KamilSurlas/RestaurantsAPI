using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Commands.Abstracts
{
    public abstract class UserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}
