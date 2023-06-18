﻿namespace UsersApiStudy.src.Models;

public class Contact
{
    public Guid ContactId { get; set; }
    public string? Linkedin { get; set; }
    public string? Github { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}

