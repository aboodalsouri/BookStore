using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    [Table("Gategory")]
    public class Gategory
    {
        public int id { set; get; }
        public int Code { set; get; }
        [Required(ErrorMessage = ("Fill your name"))]
        public string Name { set; get; }
        
    }
}
