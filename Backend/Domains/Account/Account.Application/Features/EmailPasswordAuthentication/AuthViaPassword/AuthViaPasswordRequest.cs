using Account.Application.Abstractions;
using Account.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequest : IResultRequest<string>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}