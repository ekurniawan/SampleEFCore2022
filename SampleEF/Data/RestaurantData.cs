using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleEF.Models;

namespace SampleEF.Data
{
    public class RestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;
        public RestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{Id=1,Name="Por Aqui Mexican Restaurant"},
                new Restaurant{Id=2,Name="El Primo Sausage"},
                new Restaurant{Id=3,Name="Pasta Banget Restaurant"}
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Restaurant Insert(Restaurant obj)
        {
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant obj)
        {
            throw new NotImplementedException();
        }
    }
}