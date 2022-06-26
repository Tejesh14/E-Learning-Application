using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using E_Learning.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories
{
    public class StudentRepository : ILearnRepository<Student>
    {
        public readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Add(Student data)
        {
            data.Id = Guid.NewGuid().ToString();
            var student = await _dbContext.Students.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Student> Delete(string id)
        {
            var find = await _dbContext.Students.FindAsync(id);
            _dbContext.Students.Remove(find);
            await _dbContext.SaveChangesAsync();
            return find;
        }

         public async Task<Student> Edit(string id, Student data)
        {
            var find = await _dbContext.Students.FindAsync(id);
            find.Name = data.Name;
            find.Email = data.Email;
            find.Address = data.Address;
            find.DateOfBirth = data.DateOfBirth;
            find.FathersName = data.FathersName;
            find.age = data.age;
            find.MothersName = data.MothersName;
            find.ContactNumber = data.ContactNumber;

            await _dbContext.SaveChangesAsync();
            return find;
        }

        public async Task<List<Student>> Get()
        {
            var findAll = await _dbContext.Students.ToListAsync();
            return findAll;
        }

        public async Task<Student> GetByUserName(string username)
        {
            Student find = await _dbContext.Students.FirstOrDefaultAsync(x => x.Username == username);
            return find;
        }

        public async Task<Student> Search(string id)
        {
            var find = await _dbContext.Students.FindAsync(id);
            return find;
        }

        public async Task<Chat> SendMessage(Chat chat)
        {
            chat.Id = Guid.NewGuid().ToString();
            chat.SendAt = DateTime.Now;
            var chatData = await _dbContext.Chats.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
            return chatData.Entity;
        }
    }
}