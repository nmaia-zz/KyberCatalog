using Project.Business.Concrete.Common;
using Project.Business.Contracts;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Business.Concrete
{
    public class KyberBusiness : BusinessBase<Kyber>, IKyberBusiness
    {
        private readonly IKyberRepository _kyberRepository;

        public KyberBusiness(IKyberRepository kyberRepository)
        {
            _kyberRepository = kyberRepository;
        }

        public override async Task<bool> Exists(Kyber obj)
        {
            var allKybers = await _kyberRepository.GetAllAsync();

            //var kyberCollection = new ObservableCollection<Kyber>(allKybers);
            //return kyberCollection.Where(k => k.Name == obj.Name).FirstOrDefault() != null;

            return allKybers.Any(k => k.Name == obj.Name);
        }
    }
}
