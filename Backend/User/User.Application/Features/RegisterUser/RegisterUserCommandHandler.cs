using MediatR;
using Microsoft.AspNetCore.Identity;
using User.Application.Services;
using User.Domain.Abstractions;
using User.Domain.Entities;

namespace User.Application.Features.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IPasswordService _passwordService;


    public RegisterUserCommandHandler(IPasswordService passwordService, IRepository<UserEntity> userRepository)
    {
        _passwordService = passwordService;
        _userRepository = userRepository;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordService.CreateHash(request.Password);
        
        var newEntity = new UserEntity(
            username: request.Username,
            passwordHash: passwordHash);

        await _userRepository.CreateAsync(newEntity);

        await _userRepository.SaveChangesAsync();
    }
}