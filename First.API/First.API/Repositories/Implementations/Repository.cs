﻿using First.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace First.API.Repositories.Implementations
{
    public class Repository : IRepository
    {
        public readonly AppDbContext _context; 
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.AddAsync(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c=>c.Id==id);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       

    }
}
