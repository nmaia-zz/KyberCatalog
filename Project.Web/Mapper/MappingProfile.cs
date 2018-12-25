using AutoMapper;
using Project.Domain.Entities;
using Project.Web.Models;

namespace Project.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper for registration
            CreateMap<KyberCreateViewMdel, Kyber>();
            CreateMap<Kyber, KyberCreateViewMdel>();

            //Mapper for edition
            CreateMap<KyberEditViewMdel, Kyber>();
            CreateMap<Kyber, KyberEditViewMdel>();
        }
    }
}
