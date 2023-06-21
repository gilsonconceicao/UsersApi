using System.ComponentModel.DataAnnotations;
using UsersApi.src.Enums;
using UsersApiStudy.src.Models;

namespace UsersApi.src.Models;

public class Permissions
{
    [Key]
    [Required]
    public Guid UserId { get; set; }
    public PermissionsEnum UserPermissions { get; set; }
    public virtual User User { get; set; }
}
