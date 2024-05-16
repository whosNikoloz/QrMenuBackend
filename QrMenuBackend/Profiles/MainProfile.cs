using AutoMapper;
using QrMenuBackend.Models;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
namespace QrMenuBackend.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductGroup, ProductGroupDto>();
            CreateMap<ProductGroupDto, ProductGroup>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductCreateDto>();

        }
    }
}
