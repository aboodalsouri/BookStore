using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
   public interface IAutherService
    {
        List<Auther> LoadAll();
        void Insert(Auther A);
        Auther Edit(int id);
        void Delete(int Id);
        void Update(Auther A);
    }
}
