using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectRepository(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public async Task<Project> AssignProject(IFormFile file, string facultyName, string project, string assignTo)
        {
            if (file.Length > 0 && file != null)
            {
                string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string ID = Guid.NewGuid().ToString();
                using (FileStream fs = System.IO.File.Create(path + ID))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    Project fileData = new Project()
                    {
                        Id = ID,
                        FileNameAssigned = file.FileName,
                        FileTypeAssigned = file.ContentType,
                        AssignedAt = DateTime.Now,
                        AssignBy = facultyName,
                        ProjectName = project,
                        AssignTo = assignTo
                    };

                    var data = await _dbContext.Projects.AddAsync(fileData);
                    await _dbContext.SaveChangesAsync();
                    return data.Entity;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Project> Delete(string id)
        {
            var data = await _dbContext.Projects.FindAsync(id);
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            System.IO.File.Delete(path + id);
            _dbContext.Projects.Remove(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public async Task<Project> Edit(string id, IFormFile file, string project)
        {
            var projectData = await _dbContext.Projects.FindAsync(id);
            if (file.Length > 0 && file != null)
            {
                string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
                System.IO.File.Delete(path + id);

                using (FileStream fs = System.IO.File.Create(path + id))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    projectData.ProjectName = project;
                    projectData.FileTypeAssigned = file.ContentType;
                    projectData.FileNameAssigned = file.FileName;

                    await _dbContext.SaveChangesAsync();
                    return projectData;
                }
            }
            else
            {
                projectData.ProjectName = project;
                await _dbContext.SaveChangesAsync();
                return projectData;
            }
        }

        public async Task<List<Project>> Get()
        {
            var list = await _dbContext.Projects.ToListAsync();
            return list;
        }

        public async Task<List<Project>> Get(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = await _userManager.GetRolesAsync(user);
            List<Project> list;
            if(role[0] == "Student")
            {
                list = await _dbContext.Projects.Where(x => x.AssignTo == userName).ToListAsync();
                return list;
            }else if(role[0] == "Faculty")
            {
                list = await _dbContext.Projects.Where(x => x.AssignBy == userName).ToListAsync();
                return list;
            }
            return null;
        }

        public async Task<List<Project>> GetUnSubmitted(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = await _userManager.GetRolesAsync(user);
            List<Project> list;
            if (role[0] == "Student")
            {
                list = await _dbContext.Projects.Where(x => x.AssignTo == userName && x.FileNameSubmitted == null).ToListAsync();
                return list;
            }
            return null;
        }

        public async Task<Project> GetProject(string id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task<Project> SubmitProject(string id, IFormFile file, string studentName)
        {
            var projectData = await _dbContext.Projects.FindAsync(id);
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            if (file.Length > 0 && file != null)
            {
                using (FileStream fs = System.IO.File.Create(path + file.FileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    projectData.SubmittedAt = DateTime.Now;
                    projectData.FileTypeSubmitted = file.ContentType;
                    projectData.FileNameSubmitted = file.FileName;

                    await _dbContext.SaveChangesAsync();
                    return projectData;
                }
            }
            return null;
        }
    }
}
