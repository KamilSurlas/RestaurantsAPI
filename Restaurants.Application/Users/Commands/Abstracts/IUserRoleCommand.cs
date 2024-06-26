using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Commands.Abstracts
{
    public interface IUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } 
        public string RoleName { get; set; } 
    }
}
