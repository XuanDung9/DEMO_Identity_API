using Data_DEMO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_DEMO.DataContext
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {
            
        }
        #region DbSet
        public DbSet<Products>? Products { get; set; }  
        #endregion
    }
}
