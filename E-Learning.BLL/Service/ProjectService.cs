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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }
        public Task<Project> AssignProject(IFormFile file, string facultyName, string project, string assignTo)
        {
            return _projectRepo.AssignProject(file, facultyName, project, assignTo);
        }

        public async Task<Project> Delete(string id)
        {
            return await _projectRepo.Delete(id);
        }

        public async Task<Project> Edit(string id, IFormFile file, string project)
        {
            return await _projectRepo.Edit(id, file, project);
        }

        public async Task<List<Project>> Get(string userName)
        {
            return await _projectRepo.Get(userName);
        }
        
        public async Task<List<Project>> Get()
        {
            return await _projectRepo.Get();
        }

        public async Task<Project> GetProject(string id)
        {
            return await _projectRepo.GetProject(id);
        }
        public async Task<List<Project>> GetUnSubmitted(string userName)
        {
            return await _projectRepo.GetUnSubmitted(userName);
        }

        public async Task<Project> SubmitProject(string id, IFormFile file, string studentName)
        {
            return await _projectRepo.SubmitProject(id, file, studentName);
        }
    }
}
