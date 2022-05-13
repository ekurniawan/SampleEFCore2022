using SampleEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Dal
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetByName(string name);
    }
}
