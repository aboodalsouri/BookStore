using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CountryService: ICountryService
    {
        BScontext context;
        public CountryService(BScontext _context)
        {
            context =_context;
        }
        public void Insert(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
        }
        
        public List<Country> LoadAll()
        {
            List<Country> li= context.Countries.ToList();
            return li;
        }
    }
}
