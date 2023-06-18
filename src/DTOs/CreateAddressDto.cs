﻿using System.ComponentModel.DataAnnotations;

namespace UsersApiStudy.src.DTOs;
public class CreateAddressDto
{
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
