﻿namespace Account.Service.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}