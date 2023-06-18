using AutoMapper;
using UsersApiStudy.src.DTOs;
using UsersApiStudy.src.Models;

namespace UsersApiStudy.src.Profiles;

public class ContectProfile : Profile
{
    public ContectProfile()
    {
        CreateMap<CreateContactDto, Contact>();
        CreateMap<Contact, ReadContactDto> ();
    }
}
