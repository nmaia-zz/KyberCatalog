using Project.Business.Contracts.Common;
using System;
using System.Threading.Tasks;

namespace Project.Business.Concrete.Common
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity> where TEntity : class
    {
        public virtual async Task<bool> Exists(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
