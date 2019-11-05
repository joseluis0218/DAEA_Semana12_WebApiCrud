using DataAccessLayer;
using AutoMapper;

namespace WebAPIService.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Models.Product, Product>();
            Mapper.CreateMap<Product, Models.Product>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}