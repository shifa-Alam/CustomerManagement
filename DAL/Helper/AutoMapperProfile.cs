

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, CountryInputModel>().ReverseMap();
            CreateMap<Customer, CustomerInputModel>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressInputModel>().ReverseMap();
            //CreateMap<Product, ProductViewModel>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(y => y.Category.Name).ToList()));
        }
    }
}
