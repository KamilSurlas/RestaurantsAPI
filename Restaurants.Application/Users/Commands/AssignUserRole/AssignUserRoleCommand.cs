using MediatR;
using Restaurants.Application.Users.Commands.Abstracts;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommand : IUserRoleCommand
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}
