using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BScontext : IdentityDbContext<ApplicationUser>
    {
        IConfiguration config;
        public BScontext(IConfiguration _config)
        {
            config = _config;
        }
        public DbSet<Book> Books { set; get; }
        public DbSet<Auther> Authers { set; get; }
        public DbSet<Gategory> Gategories { set; get; }
        public DbSet<Country> Countries { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("BSConnection"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
