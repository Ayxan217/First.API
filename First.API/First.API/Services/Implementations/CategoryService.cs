﻿using First.API.DTOs.Category;
using First.API.DTOs.Product;
using First.API.Repositories.Interfaces;
using First.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace First.API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<bool> CreateAsync(CreateCategoryDTO categoryDTO)
        {
            if(await _categoryRepository.AnyAsync(c=>c.Name == categoryDTO.Name)) return false;

            await _categoryRepository.AddAsync(new Category { Name = categoryDTO.Name });
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

      

        public async Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int page, int take)
        {

            IEnumerable<GetCategoryDTO> categories = await _categoryRepository
                .GetAll(skip:(page-1)*take,take:take)
                .Select
                ( 
                    c => new GetCategoryDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ProductCount = c.Products.Count
                    }
                ).ToListAsync();
            return categories;

        }

        public async Task<GetCategoryDetailDTO> GetByIdAsync(int id)
        {
           Category category = await _categoryRepository.GetByIdAsync(id,nameof(Category.Products));

            if (category is null) return null;

            GetCategoryDetailDTO categoryDTO = new()
            {
                Id = category.Id,
                Name = category.Name,
                ProductDTOs = category.Products.Select(p=>new GetProductDTO
                {
                    Id=p.Id,
                    Name=p.Name,
                    Price = p.Price,
                }).ToList()
            };

            return categoryDTO;
        }

        public async Task UpdateAsync(int id, UpdateCategroryDTO categroryDTO)
        {
           Category category = await _categoryRepository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not Found");

            if (await _categoryRepository
                .AnyAsync(c => c.Name == categroryDTO.Name && c.Id == id) )
            {
                throw new Exception("Alredy Exists");
            }
              
            category.Name = categroryDTO.Name;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
            
        }


        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not Found");

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}