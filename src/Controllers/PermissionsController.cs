using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersApi.src.DTOs;
using UsersApi.src.Models;
using UsersApiStudy.src.Contexts;

namespace UsersApi.src.Controllers;
[Route("/v1/[Controller]")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private UsersContext _dbContext;
    private IMapper _mapper;

    public PermissionsController(UsersContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public IActionResult GetPermissionById (Guid userId) 
    {   
        var user = _dbContext.Users.FirstOrDefault(user => user.UserId == userId); 

        if (userId == null) return BadRequest("Usuário não existe"); 

        var permission = _mapper.Map<Permissions, ReadPermissionDto>(user!.Permissions); 

        return Ok(permission); 
    }

    [HttpPost("/v1/AddPermission/{userId}")]
    public IActionResult AddPermissionById(Guid userId, [FromBody] CreatePermission permission)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);

        if (user == null) return NotFound("Usuário não encontrado.");

        if (user.Permissions != null)
        {
            if (Convert.ToInt32(permission.UserPermissions) == Convert.ToInt32(user.Permissions.UserPermissions))
            {
                return BadRequest("Usuário já possui essa permissão.");
            }
        }

        try
        {
            Permissions newPermission = _mapper.Map<CreatePermission, Permissions>(permission);
            newPermission.UserId = user.UserId;
            if (user.Permissions == null)
            {
                _dbContext.Permissions.Add(newPermission);
            }
            else
            {
                _dbContext.Entry(user.Permissions).CurrentValues.SetValues(newPermission);
            }
            _dbContext.SaveChanges();
            return Ok(_mapper.Map<Permissions, ReadPermissionDto>(newPermission));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
