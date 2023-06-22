using System.ComponentModel;
namespace UsersApi.src.Enums;

[Flags]
public enum PermissionsEnum
{
    [Description("None")]
    None = 0,
    [Description("Read")]
    Read = 1,
    [Description("Delete")]
    Delete = 2,
    [Description("Create")]
    Create = 4,
    [Description("Master")]
    Master = 8
}
