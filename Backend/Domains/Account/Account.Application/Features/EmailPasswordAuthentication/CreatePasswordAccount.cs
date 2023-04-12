﻿using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Services;
using Catton.Utilities;
using FluentValidation;
using MediatR;

namespace Account.Service.Features.EmailPasswordAuthentication;

public class CreatePasswordAccountRequestContract
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
}

public class CreatePasswordAccountRequest : IResultRequest
{
    public CreatePasswordAccountRequest(CreatePasswordAccountRequestContract requestContract)
    {
        Email = requestContract.Email;
        Password = requestContract.Password;
        Username = requestContract.Username;
    }

    public string Email { get; }
    public string Password { get; }
    public string Username { get; }
}

public class CreatePasswordAccountValidator : AbstractValidator<CreatePasswordAccountRequest>
{
    private const string PasswordRegex = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$";
    //     Contain at least one letter (uppercase or lowercase) using the (?=.*[A-Za-z]) lookahead assertion.
    //     Contain at least one digit using the (?=.*\d) lookahead assertion.
    //     Contain at least one special character from the set @$!%*#?& using the (?=.*[@$!%*#?&]) lookahead assertion.
    ////// Be at least 8 characters long using the {8,} quantifier
    
    
    public CreatePasswordAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).Matches(PasswordRegex);;
    }
}

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
        var accountCreationResult = await PasswordAccountEntity.CreateAsync(
            email: request.Email,
            username: request.Username,
            passwordHash: _hashingService.HashPassword(request.Password)
        );

        var saveInDatabaseResult = await accountCreationResult.Match(
            Fail: exception => Task.FromResult(new Result<Unit>(exception)),
            Succ: async entity =>
            {
                await _passwordAccountRepository.AddAsync(entity);

                var dbException = await _passwordAccountRepository.SaveChangesAsync();

                if (dbException is not null)
                    return new Result<Unit>(dbException);
        
                return new Result<Unit>(Unit.Value);
            }
        );
        
        return saveInDatabaseResult;
    }
}