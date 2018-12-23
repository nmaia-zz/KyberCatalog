using AutoMapper;
using Project.Domain.Entities;
using Project.Web.Models;

namespace Project.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KyberViewMdel, Kyber>();
            CreateMap<Kyber, KyberViewMdel>();
        }
    }
}
