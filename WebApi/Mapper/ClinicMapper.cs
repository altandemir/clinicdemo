using WebApi.Domain;

namespace WebApi.Mapper;

public class ClinicMapper : ICsvMapper<Clinic>
{
    public Clinic From(string line)
    {
        var values = line.Split(',');
        return int.TryParse(values[0], out var id) ? new Clinic(id, values[1]) : new Clinic();
    }
}