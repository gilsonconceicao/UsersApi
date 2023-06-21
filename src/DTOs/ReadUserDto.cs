using System.ComponentModel.DataAnnotations;
using UsersApi.src.DTOs;

namespace UsersApiStudy.src.DTOs;
public class ReadUserDto
{
    public Guid UserId{ get; set; } 
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Job { get; set; }
    public string Nationality { get; set; } 
    public ReadAddressDto Address { get; set; } 
    public ReadContactDto Contact { get; set; }
    public ReadPermission Permission { get; set; }
}
