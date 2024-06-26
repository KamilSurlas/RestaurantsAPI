using MediatR;
using Restaurants.Application.Users.Commands.Abstracts;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
    public class UnassignUserRoleCommand : IUserRoleCommand
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
  }
