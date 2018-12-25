using System.Threading.Tasks;

namespace Project.Business.Contracts.Common
{
    public interface IBusinessBase<TEntity> where TEntity : class
    {
        Task<bool> Exists(TEntity obj);

        Task<bool> CanEdit(TEntity obj);
    }
}
