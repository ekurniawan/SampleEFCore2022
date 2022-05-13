using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Dal
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task Delete(int id);
    }
}
