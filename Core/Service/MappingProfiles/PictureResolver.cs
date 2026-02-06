using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    internal class PictureResolver(IConfiguration configuration) : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            // check if picture is null
            if(string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }
            else
            {
                //var url = $"https://localhost:7055/{source.PictureUrl}";
                // use the url from the appsettings.json file
                // to access the url from the appsettings.json file, we need to use the IConfiguration interface
                // we can inject the IConfiguration interface in the constructor of the PictureResolver class
                // download the Microsoft.Extensions.Configuration package to use the IConfiguration interface
                var url = $"{configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return url;
            }
        }
    }
}
