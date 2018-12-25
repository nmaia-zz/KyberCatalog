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

        //ToDo: We're having some issue here with the EF. Tracked entities cannot be updated. 
        //It's necessary to detach them in dbcontext before updating.
        [Obsolete("This method must be refactored in order to avoid an exception from entity framework. We're using the try/catch to handle it in MVC controller for entity updates.")]
        public override async Task<bool> CanEdit(Kyber obj)
        {
            var allKybers = await _kyberRepository.GetAllAsync();
            return (allKybers.Where(k => k.Name == obj.Name).Count() > 1) ? false : true;
        }
    }
}
