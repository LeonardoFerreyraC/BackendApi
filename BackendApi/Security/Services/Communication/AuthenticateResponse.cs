﻿namespace BackendApi.Security.Services.Communication;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Birthday { get; set; }
    public string Token { get; set; }
}