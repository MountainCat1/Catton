﻿namespace ConventionDomain.Application.Dtos.Convention;

public record ConventionCreateDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}