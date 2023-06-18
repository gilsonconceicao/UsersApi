﻿namespace UsersApiStudy.src.DTOs;
public class ReadAddressDto
{
    public Guid AddressId { get; set; } 
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public Guid UserId { get; set; }
}
