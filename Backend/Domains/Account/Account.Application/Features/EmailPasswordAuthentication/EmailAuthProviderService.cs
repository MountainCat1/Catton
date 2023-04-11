﻿using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Dtos;
using Account.Service.Extensions.DtoMapping;
using Account.Service.Services;
using Account.Service.Services.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;

namespace Account.Service.Features.EmailPasswordAuthentication;

public interface IPasswordAuthProviderService : IAuthProviderService<PasswordAccountEntity>
{
    public Task<Result<AccountDto>> ValidateCredentials(CredentialsModel credentialsModel);
}

public class PasswordAuthProviderService : IPasswordAuthProviderService
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;
    private readonly IHashingService _hashingService;


    public PasswordAuthProviderService(IPasswordAccountRepository passwordAccountRepository, IHashingService hashingService)
    {
        _passwordAccountRepository = passwordAccountRepository;
        _hashingService = hashingService;
    }

    public async Task<Result<AccountDto>> ValidateCredentials(CredentialsModel credentialsModel)
    {
        var account = await _passwordAccountRepository
            .GetOneAsync(x => x.Email == credentialsModel.Email);

        if (account is null)
        {
            return new Result<AccountDto>(new ValidationException("Account does not exist", new[]
            {
                new ValidationFailure(nameof(CredentialsModel.Email), "Account with provided email does not exist")
            }));
        }

        if (!_hashingService.VerifyPassword(account.PasswordHash, credentialsModel.Password))
        {
            return new Result<AccountDto>(new ValidationException("Password does not match", new[]
            {
                new ValidationFailure(nameof(CredentialsModel.Password), "Password does not match")
            }));
        }

        return account.ToDto();
    }
}