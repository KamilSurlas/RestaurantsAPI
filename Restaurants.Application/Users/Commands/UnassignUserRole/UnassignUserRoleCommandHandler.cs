using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users.Commands.Abstracts;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
    public class UnassignUserRoleCommandHandler : UserRoleCommandHandler<UnassignUserRoleCommand>
    {
        private readonly ILogger _logger;
        public UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : base(userManager, roleManager)
        {
            _logger = logger;
        }
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Unassigning user role: {@Request}", request);

            await base.Handle(request, cancellationToken);
        }

        protected override async Task HandleUserRoleOperation(User user, IdentityRole role)
        {
            await _userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
