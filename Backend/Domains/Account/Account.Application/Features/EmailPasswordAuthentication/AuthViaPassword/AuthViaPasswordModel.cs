﻿namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}