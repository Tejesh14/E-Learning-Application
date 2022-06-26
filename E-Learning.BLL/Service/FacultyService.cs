using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class FacultyService : ILearnService<Faculty>
    {
        private readonly ILearnRepository<Faculty> _facultyRepo;
        private readonly IProjectRepository _projectRepo;
        public FacultyService(ILearnRepository<Faculty> facultyRepo, IProjectRepository projectRepo)
        {
            _facultyRepo = facultyRepo;
            _projectRepo = projectRepo;
        }

        public async Task<Faculty> Add(Faculty data)
        {
            return await _facultyRepo.Add(data);
        }

        public async Task<Faculty> Delete(string id)
        {
            return await _facultyRepo.Delete(id);
        }

        public async Task<Faculty> Edit(string id, Faculty data)
        {
            return await _facultyRepo.Edit(id, data);
        }

        public async Task<List<Faculty>> Get()
        {
            return await _facultyRepo.Get();
        }

        public async Task<Faculty> Search(string id)
        {
            return await _facultyRepo.Search(id);
        }

        public async Task<Project> AssignProject(IFormFile file, string facultyName, string project, string assignTo)
        {
            return await _projectRepo.AssignProject(file, facultyName, project, assignTo);
        }

        public Task<Faculty> GetByUserName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
