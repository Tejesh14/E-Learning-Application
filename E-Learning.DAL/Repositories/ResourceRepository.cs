using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories
{
    public class ResourceRepository : IResourceRepository<Resources>
    {
        private readonly ApplicationDbContext _dbContext;
        public ResourceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Resources> Add(Resources resources)
        {
            resources.Time = DateTime.Now;
            resources.Id = Guid.NewGuid().ToString();
            var data = await _dbContext.Resources.AddAsync(resources);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Resources> Delete(string id)
        {
            var find = await _dbContext.Resources.FindAsync(id);
            var data = _dbContext.Resources.Remove(find);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Resources> Edit(string id, Resources resources)
        {
            var find = await _dbContext.Resources.FindAsync(id);
            find.Body = resources.Body;
            find.Heading = resources.Heading;
            find.Time = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return find;
        }

        public async Task<List<Resources>> Get()
        {
            var data = await _dbContext.Resources.ToListAsync();
            return data;
        }

        public async Task<Resources> Get(string id)
        {
            var find = await _dbContext.Resources.FindAsync(id);
            return find;
        }
    }
}
