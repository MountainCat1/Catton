using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Authorization;

public static class Policies
{
    public const string CreateOrganizer = nameof(CreateOrganizer);
    public const string ReadConvention = nameof(ReadConvention);
}