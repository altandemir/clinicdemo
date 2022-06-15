using WebApi.Domain;

namespace WebApi.Infrastructure;

public interface IClinicReader
{
    Task<List<Clinic>> Read();
}