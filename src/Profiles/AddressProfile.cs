using AutoMapper;
using UsersApiStudy.src.DTOs;
using UsersApiStudy.src.Models;

namespace UsersApiStudy.src.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto > ();
    }
}
