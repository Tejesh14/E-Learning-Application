using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class ResourceService : IReService<Resources>
    {
        private readonly IResourceRepository<Resources> _resourceRepo;
        public ResourceService(IResourceRepository<Resources> resourceRepo)
        {
            _resourceRepo = resourceRepo;
        }

        public async Task<Resources> Add(Resources resources)
        {
            return await _resourceRepo.Add(resources);
        }

        public async Task<Resources> Delete(string id)
        {
            return await _resourceRepo.Delete(id);
        }

        public async Task<Resources> Edit(string id, Resources resources)
        {
            return await _resourceRepo.Edit(id, resources);
        }

        public async Task<List<Resources>> Get()
        {
            return await _resourceRepo.Get();
        }

        public async Task<Resources> Get(string id)
        {
            return await _resourceRepo.Get(id);
        }
    }
}
