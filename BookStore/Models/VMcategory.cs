using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMcategory
    {
        public Gategory categore { get; set; }
        public List<Gategory> licategories { get; set; }
    }
}
