using WebApi.Domain;

namespace WebApi.Infrastructure;

public interface IPatientReader
{
    Task<List<Patient>> Read();
}