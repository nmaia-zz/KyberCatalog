using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Project.Repository.Repositories.Common;
using System.Linq;

namespace Project.Repository.Repositories
{
    public class KyberRepository : RepositoryBase<Kyber>, IKyberRepository
    {
        public override int GetByNameCount(string name)
        {
            return db.Kybers.Where(k => k.Name == name).Count();
        }
    }
}
