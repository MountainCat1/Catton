﻿namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
}