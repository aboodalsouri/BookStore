using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
   public interface IGategoryService
    {
        List<Gategory> LoadAll();
        void Insert(Gategory C);
        Gategory Edit(int id);
        void Delete(int Id);
        void Update(Gategory C);
    }
}

