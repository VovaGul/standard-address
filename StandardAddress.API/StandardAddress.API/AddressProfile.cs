using AutoMapper;
using Dadata.Model;

namespace StandardAddress.API;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>();
    }
}