using Account.Application.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IResultRequest<string>
{
    public required string GoogleAuthToken { get; set; }
}