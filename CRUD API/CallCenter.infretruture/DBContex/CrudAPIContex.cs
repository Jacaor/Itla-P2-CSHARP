using Microsoft.EntityFrameworkCore;
using CallCenter.infretruture.Model;
namespace CallCenter.infretruture.DBContex
{
    public class CrudAPIContex: DbContext
    {
        public CrudAPIContex(DbContextOptions<CrudAPIContex> options) : base(options)
        {
        }
        public DbSet<ManagerModel> Managers { get; set; }
    





    }
}
