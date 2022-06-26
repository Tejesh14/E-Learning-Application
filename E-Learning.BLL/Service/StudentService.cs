using E_Learning.DAL.Models;
using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class StudentService : ILearnService<Student>
    {
        private readonly ILearnRepository<Student> _studentRepo;

        public StudentService(ILearnRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<Student> Add(Student data)
        {
            return await _studentRepo.Add(data);
        }

        public async Task<Student> Delete(string id)
        {
            return await _studentRepo.Delete(id);
        }

        public async Task<Student> Edit(string id, Student data)
        {
            return await _studentRepo.Edit(id, data);
        }

        public async Task<List<Student>> Get()
        {
            return await _studentRepo.Get();
        }

        public async Task<Student> GetByUserName(string username)
        {
            return await _studentRepo.GetByUserName(username);
        }

        public async Task<Student> Search(string id)
        {
            return await _studentRepo.Search(id);
        }
    }
}
