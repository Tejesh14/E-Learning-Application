using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Interface
{
    public interface IProjectRepository
    {
        Task<Project> AssignProject(IFormFile file, string facultyName, string project, string assignTo);
        Task<Project> SubmitProject(string id, IFormFile file, string studentName);
        Task<List<Project>> Get(string userName);
        Task<Project> GetProject(string id);
        Task<List<Project>> Get();
        Task<List<Project>> GetUnSubmitted(string userName);
        Task<Project> Edit(string id, IFormFile file, string project);
        Task<Project> Delete(string id);
    }
}
