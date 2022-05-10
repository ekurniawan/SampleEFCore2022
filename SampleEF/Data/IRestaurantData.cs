using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleEF.Models;

namespace SampleEF.Data
{
    public interface IRestaurantData : ICrud<Restaurant>
    {
        IEnumerable<Restaurant> GetByName(string name);
    }
}