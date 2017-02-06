using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.DataContext
{
    class NewsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> New_s { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
