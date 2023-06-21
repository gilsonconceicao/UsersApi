using System.ComponentModel.DataAnnotations;
using UsersApi.src.Models;

namespace UsersApiStudy.src.Models;
public class User
{
    [Key]
    [Required]
    public Guid UserId { get; set; } 
    [Required(ErrorMessage = "Nome precisa ser preenchido")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Sobrenome precisa ser preenchido")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Idade precisa ser preenchido")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Data de nascimento precisa ser preenchido")]
    public DateTime BirthDate { get; set; }
    [Required(ErrorMessage = "Trabalho precisa ser preenchido")]
    public string Job { get; set; }
    [Required(ErrorMessage = "Nacionalidade precisa ser preenchido")]
    public string Nationality { get; set; }
    public virtual Address Address { get; set; }
    public virtual Contact Contact { get; set; }
    public virtual Permissions Permissions { get; set; }
} 
