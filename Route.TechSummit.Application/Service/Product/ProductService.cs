﻿using AutoMapper;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.DTOs.ProductDTOs;
using Route.TechSummit.Infrastructure.Repository;

namespace Route.TechSummit.Application.Service.product
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repositoryManager.ProductRepository.AddAsync(product);
            await _repositoryManager.UnitOfWork.CompleteAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductUpdateDto productDto)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                // Handle not found exception
                return;
            }
            _mapper.Map(productDto, product);
            await _repositoryManager.ProductRepository.UpdateAsync(product);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repositoryManager.ProductRepository.DeleteAsync(id);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }
    }
}
