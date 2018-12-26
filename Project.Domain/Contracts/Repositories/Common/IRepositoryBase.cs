using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Domain.Contracts.Repositories.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(TEntity obj);
        Task<IEnumerable<TEntity>> SearchByNameOrColor(string searchObj);
    }
}
