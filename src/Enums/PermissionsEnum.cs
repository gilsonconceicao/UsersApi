namespace UsersApi.src.Enums;

[Flags]
public enum PermissionsEnum
{
    None = 0,
    Read = 1,
    Delete = 2,
    Create = 3,
    Master = 4
}
