using AutoMapper;
using CapstoneBackend.DTOs;
using CapstoneBackend.Models;

namespace CapstoneBackend.MapProfiles;

public class ProductProfile : Profile // this class inherits from AutoMapper profile class  
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
    }
}