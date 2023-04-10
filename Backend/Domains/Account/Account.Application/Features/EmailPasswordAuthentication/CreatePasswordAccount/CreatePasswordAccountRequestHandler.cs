using Account.Application.Abstractions;
using Account.Application.Services;
using Account.Domain.DomainEvents;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using FluentValidation;
using LanguageExt;
using LanguageExt.Common;

namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequestHandler : IResultRequestHandler<CreatePasswordAccountRequest>
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;
    private readonly IHashingService _hashingService;
    
    public CreatePasswordAccountRequestHandler(IPasswordAccountRepository passwordAccountRepository, IHashingService hashingService)
    {
        _passwordAccountRepository = passwordAccountRepository;
        _hashingService = hashingService;
    }

    public async Task<Result<Unit>> Handle(CreatePasswordAccountRequest request, CancellationToken cancellationToken)
    {
        // var validationResult = await new CreatePasswordAccountValidator().ValidateAsync(request, cancellationToken);
        //
        // if (!validationResult.IsValid)
        // {
        //     return new Result<Unit>(new ValidationException(validationResult.Errors));
        // }
        
        var googleAccount = new PasswordAccountEntity()
        {
            Email = request.Email,
            PasswordHash = _hashingService.HashPassword(request.Password),
            Username = request.Username,
        };

        var createdEntity = await _passwordAccountRepository.CreateAsync(googleAccount);
        
        createdEntity.AddDomainEvent(new CreateAccountDomainEvent());
        
        var dbException = await _passwordAccountRepository.SaveChangesAsync();

        if (dbException is not null)
            return new Result<Unit>(dbException);
        
        return new Result<Unit>(Unit.Default);
    }
}