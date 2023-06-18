using System.ComponentModel.DataAnnotations;
namespace UsersApiStudy.src.Models;
public class Address
{
    [Key] 
    public Guid AddressId { get; set; } 

    [Required(ErrorMessage = "Rua deve ser preenchida")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Número deve ser preenchido")]
    public string Number { get; set; }  

    [Required(ErrorMessage = "Cidade deve ser preenchida")]
    public string City { get; set; }

    [Required(ErrorMessage = "Estado deve ser preenchido")]
    public string? State { get; set; }

    [Required(ErrorMessage = "CEP deve ser preenchido")]
    public string ZipCode { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
