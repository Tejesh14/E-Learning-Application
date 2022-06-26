using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class CalendarService : IReService<Calendar>
    {
        private readonly IResourceRepository<Calendar> _calenderRepo;

        public CalendarService(IResourceRepository<Calendar> calenderRepo)
        {
            _calenderRepo = calenderRepo;
        }

        public async Task<Calendar> Add(Calendar obj)
        {
            return await _calenderRepo.Add(obj);
        }

        public async Task<Calendar> Delete(string id)
        {
            return await _calenderRepo.Delete(id);
        }

        public async Task<Calendar> Edit(string id, Calendar obj)
        {
            return await _calenderRepo.Edit(id, obj);
        }

        public async Task<List<Calendar>> Get()
        {
            return await _calenderRepo.Get();
        }

        public async Task<Calendar> Get(string id)
        {
            return await _calenderRepo.Get(id);
        }
    }
}
