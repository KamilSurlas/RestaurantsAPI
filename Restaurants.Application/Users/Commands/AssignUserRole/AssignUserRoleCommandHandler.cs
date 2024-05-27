using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users.Commands.Abstracts;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
    public class AssignUserRoleCommandHandler : UserRoleCommandHandler<AssignUserRoleCommand>
    {
        private readonly ILogger _logger;
        public AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager):base(userManager,roleManager)
        {
            _logger = logger;
        }
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Assigning user role: {@Request}", request);

            await base.Handle(request,cancellationToken);


        }

        protected override async Task HandleUserRoleOperation(User user, IdentityRole role)
        {
            await _userManager.AddToRoleAsync(user,role.Name!);
        }
    }
}
