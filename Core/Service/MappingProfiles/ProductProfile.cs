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
                options=>options.MapFrom(src=>src.ProductType.Name))

                // add the base url to the picture url
                /*.ForMember(dist=>dist.PictureUrl ,
                options=>options.MapFrom(src=>$"https://localhost:7055/{src.PictureUrl}"));*/
                // this is a static url

                //we use the other overload of MapFrom to use a resolver class
                .ForMember(dist => dist.PictureUrl,
                options => options.MapFrom<PictureResolver>());



            CreateMap<ProductType, TypeDTO>();
            CreateMap<ProductBrand, BrandDTO>();
        }
    }
}
