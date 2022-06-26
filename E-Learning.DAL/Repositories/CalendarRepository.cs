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
    public class CalendarRepository : IResourceRepository<Calendar>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CalendarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Calendar> Add(Calendar obj)
        {
            obj.date = DateTime.Now;
            obj.Id = Guid.NewGuid().ToString();
            var data = await _applicationDbContext.Calendars.AddAsync(obj);
            await _applicationDbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Calendar> Delete(string id)
        {
            var find = await _applicationDbContext.Calendars.FindAsync(id);
            var data = _applicationDbContext.Calendars.Remove(find);
            await _applicationDbContext.SaveChangesAsync();
            return data.Entity;

        }

        public async Task<Calendar> Edit(string id, Calendar obj)
        {
            var find = await _applicationDbContext.Calendars.FindAsync(id);
            find.Event = obj.Event;
            find.date = DateTime.Now;

            await _applicationDbContext.SaveChangesAsync();
            return find;
        }

        public async Task<List<Calendar>> Get()
        {
            var data = await _applicationDbContext.Calendars.ToListAsync();
            return data;
        }

        public async Task<Calendar> Get(string id)
        {
            var find = await _applicationDbContext.Calendars.FindAsync(id);
            return find;
        }
    }
}
