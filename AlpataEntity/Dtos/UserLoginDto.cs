﻿
using AlpataCore.Entities;

public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

