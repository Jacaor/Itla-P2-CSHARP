using Microsoft.EntityFrameworkCore;
using CallCenter.infretruture.Model;
namespace CallCenter.infretruture.DBContex
{
    public class CallCenterAPIContex: DbContext
    {
        public CallCenterAPIContex(DbContextOptions<CallCenterAPIContex> options) : base(options)
        {
        }
        public DbSet<ManagerModel> Managers { get; set; }
    





    }
}
