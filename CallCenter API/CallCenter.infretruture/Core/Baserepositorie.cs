using CallCenter.infretruture.DBContex;
using CallCenter.infretruture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.infretruture.Core
{
    public class Baserepositorie<T> : IBaserepositorie<T> where T : class
    {
        private readonly CallCenterAPIContex _contex;

        public Baserepositorie(CallCenterAPIContex contex)
        {
            _contex = contex;
        }

        public async Task<T?> Getbtid(int id)
        {
            return await _contex.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _contex.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            _contex.Set<T>().Add(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _contex.Set<T>().Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Delete(int id)
        {
            var entity = await _contex.Set<T>().FindAsync(id);
            if (entity is null)
            {
                return null;
            }

            _contex.Set<T>().Remove(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }
    }
}
