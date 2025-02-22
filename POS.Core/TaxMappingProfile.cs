using AutoMapper;
using POS.Core.Dtos;
using POS.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TaxMappingProfile : Profile
{
    public TaxMappingProfile()
    {
        CreateMap<Tax, TaxDto>().ReverseMap();
    }
}
