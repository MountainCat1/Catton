using MediatR;
using Microsoft.AspNetCore.Identity;
using User.Application.Services;
using User.Domain.Entities;
using User.Infrastructure.DatabaseContext;

namespace User.Application.Features.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly UserDbContext _userDbContext;
    private readonly IPasswordService _passwordService;


    public RegisterUserCommandHandler(UserDbContext userDbContext, IPasswordService passwordService)
    {
        _userDbContext = userDbContext;
        _passwordService = passwordService;
    }

    public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordService.CreateHash(request.Password);
        
        var newEntity = new UserEntity(
            username: request.Username,
            passwordHash: passwordHash);

        _userDbContext.Users.Add(newEntity);
        
        return Task.CompletedTask;
    }
}