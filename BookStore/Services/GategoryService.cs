using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class GategoryService: IGategoryService
    {
        BScontext context;
        public GategoryService(BScontext _context)
        {
            context = _context;
        }
        public List<Gategory> LoadAll()
        {
            List<Gategory> li = context.Gategories.ToList();
            return li;
        }
        public void Update(Gategory C)
        {
            context.Gategories.Attach(C);
            context.Entry(C).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Insert(Gategory C)
        {
            context.Gategories.Add(C);
            context.SaveChanges();
        }
        public Gategory Edit(int id)
        {
            Gategory Gat = new Gategory();
            Gat = context.Gategories.Find(id);
            return Gat;
        }
        public void Delete(int Id)
        {
            Gategory Gat = new Gategory();
            Gat = context.Gategories.Find(Id);
            context.Gategories.Remove(Gat);
            context.SaveChanges();
        }
    }
}
