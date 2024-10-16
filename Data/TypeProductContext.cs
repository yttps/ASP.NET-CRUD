using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TypeProductContext:DbContext
    {
        public TypeProductContext(DbContextOptions<TypeProductContext> options) : base(options) { }
        public DbSet<TypeProduct> ProductType { get; set; } 
    }
}
