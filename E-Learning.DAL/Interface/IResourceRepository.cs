using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Interface
{
    public interface IResourceRepository<T>
    {
        Task<List<T>> Get();
        Task<T> Get(string id);
        Task<T> Add(T obj);
        Task<T> Edit(string id, T obj);
        Task<T> Delete(string id);
    }
}
