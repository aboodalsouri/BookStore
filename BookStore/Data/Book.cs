using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Data
{
    [Table("Book")]
    public class Book
    {
        public int id { set; get; }
        [Required(ErrorMessage = ("Fill your book titel"))]
        public string BookTitel { set; get; }
        public int Year { set; get; }
        public double Price { set; get; }
        [Required(ErrorMessage = ("Fill your stock"))]
        public string Stock { set; get; }
        [ForeignKey("gategory")]
        public int Gategory_id { set; get; }
        public Gategory gategory { set; get; }
        [ForeignKey("auther")]
        public int Auther_id { set; get; }
        public Auther auther { set; get; }

        [NotMapped]
        public IFormFile image { set; get; }
        public string imagePath { set; get; }

    }
}
