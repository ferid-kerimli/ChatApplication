﻿namespace ChatApplication.BLL.Dto.Authentication;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsPersist { get; set; } 
}