using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            // first call the required repo
            var Repo = unitOfWork.GetRepository<ProductBrand,int>();

            // use the repo to get what you need
            var Brands= await Repo.GetAllAsync();

            // auto map to DTO
            // install automapper to services
            // inject object from automapper
            var BrandsDTO = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDTO>>(Brands);

            // return
            return BrandsDTO;

            // need to create mapping profile
            // need to add services to DI container

        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var Products =await unitOfWork.GetRepository<Product,int>().GetAllAsync();
            return mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(Products);
        }

        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var Types = await unitOfWork.GetRepository<ProductType,int>().GetAllAsync();
            return mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTO>>(Types);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int Id)
        {
            var Product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(Id);
            return mapper.Map<Product, ProductDTO>(Product);
        }
    }
}
