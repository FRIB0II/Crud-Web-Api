using Crud_Web_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Web_Api.Data
{
    public class MyContextdb : DbContext
    {
       public MyContextdb(DbContextOptions<MyContextdb> options) : base(options)
       {
       }

        public DbSet<UserModel> Users { get; set; }
    }
}
