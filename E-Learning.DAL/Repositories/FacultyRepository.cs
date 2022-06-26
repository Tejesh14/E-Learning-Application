using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories
{
    public class FacultyRepository : ILearnRepository<Faculty>
    {
        public readonly ApplicationDbContext _dbContext;

        public FacultyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Faculty> Add(Faculty data)
        {
            data.Id = Guid.NewGuid().ToString();
            var student = await _dbContext.Faculties.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Faculty> Delete(string id)
        {
            var find = await _dbContext.Faculties.FindAsync(id);
            _dbContext.Faculties.Remove(find);
            await _dbContext.SaveChangesAsync();
            return find;
        }

        public async Task<Faculty> Edit(string id, Faculty data)
        {
            var find = await _dbContext.Faculties.FindAsync(id);
            find.Name = data.Name;
            find.Email = data.Email;
            find.Address = data.Address;
            find.DateOfBirth = data.DateOfBirth;
            find.FathersName = data.FathersName;
            find.age = data.age;
            find.Subject = data.Subject;
            find.MothersName = data.MothersName;
            find.ContactNumber = data.ContactNumber;

            await _dbContext.SaveChangesAsync();
            return find;
        }

        public async Task<List<Faculty>> Get()
        {
            var findAll = await _dbContext.Faculties.ToListAsync();
            return findAll;
        }

        public Task<Faculty> GetByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Faculty> Search(string id)
        {
            var find = await _dbContext.Faculties.FindAsync(id);
            return find;
        }
    }
}
