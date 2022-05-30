using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AutherService: IAutherService
    {
        BScontext context;
        public AutherService(BScontext _context)
        {
            context = _context;
        }
        public List<Auther> LoadAll()
        {
            List<Auther> li = context.Authers.ToList();
            return li;
        }
        public void Update(Auther A)
        {
            context.Authers.Attach(A);
            context.Entry(A).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Insert(Auther A)
        {
            context.Authers.Add(A);
            context.SaveChanges();
        }
        public Auther Edit(int id)
        {
            Auther A = new Auther();
            A = context.Authers.Find(id);
            return A;
        }
        public void Delete(int Id)
        {
            Auther A = new Auther();
            A = context.Authers.Find(Id);
            context.Authers.Remove(A);
            context.SaveChanges();
        }
    }
}
