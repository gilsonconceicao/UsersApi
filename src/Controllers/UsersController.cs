using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersApi.src.Interfaces;
using UsersApiStudy.src.Contexts;
using UsersApiStudy.src.DTOs;
using UsersApiStudy.src.Models;

namespace UsersApiStudy.src.Controllers;
[ApiController]
[Route("/v1/[Controller]")]
public class UsersController : ControllerBase
{
    private UsersContext _dbContext;
    private IMapper _mapper;

    public UsersController( UsersContext dbContext, IMapper mapper )
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetUsers([FromQuery] int page = 0, [FromQuery] int size = 5)
    {
        var users = _mapper.Map<List<ReadUserDto>>(
            _dbContext.Users
            .Skip(page * size)
            .Take(size)
            .ToList()
        );

        return Ok(
            new DefaultGetData {
                Data = users, 
                Page = page, 
                Size = size
            }
        );
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserById (Guid userId)
    {
        var userById = _dbContext.Users
               .Include(user => user.Address)
               .FirstOrDefault(user => user.UserId == userId);

        return Ok(_mapper.Map<ReadUserDto>(userById));
    }

    [HttpPost("/v1/CreateUser")]
    public IActionResult CreateUser(CreateUserDto user)
    {
        if (user == null)
        {
            return BadRequest("Não foi possível validar informações");
        }

         User userCreated = _mapper.Map<CreateUserDto, User>(user);

        try   
        {
            userCreated.UserId = Guid.NewGuid();
            _dbContext.Add(userCreated);
            _dbContext.SaveChanges(); 

            return Ok(_mapper.Map<ReadUserDto>(userCreated));
        }
        catch (Exception)
        {
            return BadRequest("Erro ao salvar ao criar o usuário");
        }
    }

    [HttpDelete("/v1/User/{userId}")]
    public IActionResult DeleteUser(Guid userId)
    {
        var userById = _dbContext.Users
            .Include(user => user.Address)
            .FirstOrDefault(user => user.UserId == userId
        );

        if (userById == null)
        {
            return NotFound("Usuário não existe");
        }
        try
        {
            _dbContext.Remove(userById);
            _dbContext.SaveChanges();
            return Ok(); 
        }
        catch (Exception error)
        { 
            return BadRequest(error.Message);
        }
    }

    [HttpPut("/v1/UpdateUser/{userId}")]
    public IActionResult UpdateUserById (Guid userId, UpdateUserDto updateUser)
    {
        var userById = _dbContext.Users
            .Include(user => user.Address)
            .FirstOrDefault(user => user.UserId == userId
        );

        if (userById == null) 
            return NotFound("Usuário não existe");

        try 
        {
            _dbContext.Entry(userById).CurrentValues.SetValues(updateUser);
            _dbContext.SaveChanges();
            return Ok(updateUser);
        }
        catch(Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}