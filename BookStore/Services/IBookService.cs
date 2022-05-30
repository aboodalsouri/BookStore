using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        List<Book> LoadAll();
        void Insert(Book B);
        Book Edit(int id);
        void Delete(int Id);
        void Update(Book B);
    }
}
