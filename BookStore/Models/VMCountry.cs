using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMCountry
    {
        public Country Country { set; get; }
        public List<Country> licountrys { get; set; }

    }
}
