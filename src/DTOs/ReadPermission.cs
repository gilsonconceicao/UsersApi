using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.src.Enums;

namespace UsersApi.src.DTOs
{
    public class ReadPermission
    {
        public Guid UserId { get; set; }
        public PermissionsEnum UserPermissions { get; set; }
    }
}