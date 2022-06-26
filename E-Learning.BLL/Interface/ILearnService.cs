using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Interface
{
    public interface ILearnService<T>
    {
        Task<List<T>> Get();
        Task<T> GetByUserName(string username);
        Task<T> Search(string id);
        Task<T> Add(T data);
        Task<T> Delete(string id);
        Task<T> Edit(string id, T data);
    }
}
