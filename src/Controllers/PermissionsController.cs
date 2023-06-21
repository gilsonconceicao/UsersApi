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

    public PermissionsController( UsersContext context, IMapper mapper )
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpPost("/v1/AddPermission/{userId}")]
    public IActionResult AddPermissionById (Guid userId, [FromBody] CreatePermission permission) 
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
    
        if (user == null) return NotFound("Usuário não encontrado.");

        try
        {
            Permissions newPermission = _mapper.Map<CreatePermission, Permissions>(permission);
            newPermission.UserId = user.UserId;
            _dbContext.Permissions.Add(newPermission);
            _dbContext.SaveChanges();
            return Ok(newPermission);
        }
        catch(Exception) 
        {
            return BadRequest();
        }
    }
}
