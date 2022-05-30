using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMAuther
    {
        public Auther auther { set; get; }
        public List<Country> countries { set; get; }
        public List<Auther> Authers { set; get; }
    }
}
