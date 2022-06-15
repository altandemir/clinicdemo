using WebApi.Domain;

namespace WebApi.Mapper;

public class PatientMapper : ICsvMapper<Patient>
{
    public Patient From(string line)
    {
        var values = line.Split(',');
        return (int.TryParse(values[0], out var id)
                && int.TryParse(values[1], out var clinicId)
                && DateTime.TryParse(values[4], out var date)
            )
                ? new Patient(id, clinicId, values[2], values[3], date)
                : new Patient();
    }
}