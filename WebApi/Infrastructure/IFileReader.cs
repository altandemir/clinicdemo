namespace WebApi.Infrastructure;

public interface IFileReader
{
    Task<string[]> GetContent(string fileName);
}