using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Mapper;

public class PatientDtoMapper : IMapper<Patient,PatientDto>
{
    public PatientDto From(Patient patient)
    {
        return new PatientDto()
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth?.ToString("dd-MM-yyyy")
        };
    }
}