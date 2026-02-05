using AutoMapper;
using DomainLayer.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            // typename and product name must be configurated
            CreateMap<Product, ProductDTO>()
                .ForMember(dist=>dist.BrandName , 
                options=>options.MapFrom(src=>src.ProductBrand.Name))
                .ForMember(dist=>dist.TypeName , 
                options=>options.MapFrom(src=>src.ProductType.Name));

            CreateMap<ProductType, TypeDTO>();
            CreateMap<ProductBrand, BrandDTO>();
        }
    }
}
