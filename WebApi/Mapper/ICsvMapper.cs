namespace WebApi.Mapper;

public interface ICsvMapper<out T>
{
    T From(string line);
}