using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
   public interface ICountryService
    {
        void Insert(Country country);
        List<Country> LoadAll();
    }
}
