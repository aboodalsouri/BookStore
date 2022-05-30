using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMbook
    {
        public Book book { get; set; }
        public List<Book> books { get; set; }
        public List<Gategory> gategories { get; set; }
        public List<Auther> authers { get; set; }
        public List<Country> countries { get; set; }

    }
}
