using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Infrastructure;

public interface IApplicationContext
{
     List<ClinicDto> GetClinics();
     List<PatientDto> GetPatients(int clinicId, string order);
}