using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    [Table("Country")]
    public class Country
    {
        public int id { set; get; }
        public string Name { set; get; }
        public string Nationality { set; get; }

    }
}
