using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Mapper;

public class ClinicDtoMapper : IMapper<Clinic,ClinicDto>
{
    public ClinicDto From(Clinic patient)
    {
        return new ClinicDto()
        {
            Id = patient.Id,
            Name = patient.Name
        };
    }
}