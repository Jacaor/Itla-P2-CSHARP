using CallCenter.domain.Entityes;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.infretruture.DBContex
{
    public class CallCenterAPIContex : DbContext
    {
        public CallCenterAPIContex(DbContextOptions<CallCenterAPIContex> options) : base(options)
        {
        }

        public DbSet<Manager> Managers => Set<Manager>();
    }
}
