using WebApi.Domain;

namespace WebApi.Mapper;

public interface IMapper<in TSource, out TDest>
{
    TDest From(TSource patient);
}