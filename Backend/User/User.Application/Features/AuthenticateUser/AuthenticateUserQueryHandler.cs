using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Application.Services;
using User.Infrastructure.DatabaseContext;

namespace User.Application.Features.AuthenticateUser;

public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, string>
{
    private IPasswordService _passwordService;
    private UserDbContext _dbContext;

    public AuthenticateUserQueryHandler(IPasswordService passwordService, UserDbContext dbContext)
    {
        _passwordService = passwordService;
        _dbContext = dbContext;
    }

    public async Task<string> Handle(AuthenticateUserQuery request, CancellationToken ctx)
    {
        var user = await _dbContext.Users
            .FirstAsync(entity => entity.Username == request.Username, ctx);

        var validationResult = _passwordService.CheckHash(user.PasswordHash, request.Password);

        if (!validationResult.Success)
        {
            throw new NotImplementedException();
        }

        // GENERATE JWT TOKEN!
        throw new NotImplementedException();
    }
}