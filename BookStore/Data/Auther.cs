using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    [Table("Auther")]
    public class Auther
    {
        public int id { set; get; }
        [Required (ErrorMessage =("Fill your first name"))]
        public string FirstName { set; get;}
        [Required(ErrorMessage = ("Fill your last name"))]
        public string LastName { set; get; }
        [ForeignKey("country")]
        public int Country_id { set; get; }
        public Country country { set; get; }
        [NotMapped]
        public IFormFile image { set; get; }
        public string imagePath { set; get; }
        public List<Book> liBook { set; get; }

    }
}
