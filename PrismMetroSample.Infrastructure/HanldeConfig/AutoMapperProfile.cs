
using AutoMapper;
using PrismMetroSample.Infrastructure.DTO;
using PrismMetroSample.Infrastructure.Models;

namespace Max.PH6_2006A.LowCode.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginDto, User>();
        }
    }

}
