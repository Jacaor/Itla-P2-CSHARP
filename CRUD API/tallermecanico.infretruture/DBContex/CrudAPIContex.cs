using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.Model;
namespace tallermecanico.infretruture.DBContex
{
    public class CrudAPIContex: DbContext
    {
        public CrudAPIContex(DbContextOptions<CrudAPIContex> options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
    





    }
}
