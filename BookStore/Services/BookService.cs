using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService: IBookService
    {
        BScontext context;
        public BookService(BScontext _context)
        {
            context = _context;
        }
        public List<Book> LoadAll()
        {
            List<Book> li = context.Books.Include("gategory").Include("auther").ToList();
            return li;
        }
        public void Update(Book B)
        {
            context.Books.Attach(B);
            context.Entry(B).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Insert(Book B)
        {
            context.Books.Add(B);
            context.SaveChanges();
        }
        public Book Edit(int id)
        {
            Book b = new Book();
            b = context.Books.Find(id);
            return b;
        }
        public void Delete(int Id)
        {
            Book b = new Book();
            b = context.Books.Find(Id);
            context.Books.Remove(b);
            context.SaveChanges();
        }
    }
}
