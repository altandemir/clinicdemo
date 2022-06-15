using System.Linq.Expressions;
using System.Net.Mime;
using System.Reflection;
using WebApi.Domain;
using WebApi.Dto;
using WebApi.Mapper;
using static System.Linq.Expressions.Expression;

namespace WebApi.Infrastructure;

public class ApplicationContext : IApplicationContext
{
    private readonly IMapper<Patient, PatientDto> _patientMapper;
    private readonly IMapper<Clinic, ClinicDto> _clinicMapper;
    private List<Clinic> Clinics { get; }
    private List<Patient> Patients { get; }

    public ApplicationContext(IClinicReader clinicReader
        , IPatientReader patientReader
        , IMapper<Patient, PatientDto> patientMapper
        , IMapper<Clinic, ClinicDto> clinicMapper
    )
    {
        _patientMapper = patientMapper;
        _clinicMapper = clinicMapper;
        Clinics = clinicReader.Read().Result;
        Patients = patientReader.Read().Result;
    }

    public List<ClinicDto> GetClinics()
    {
        return Clinics.Select(x => _clinicMapper.From(x)).ToList();
    }

    public List<PatientDto> GetPatients(int clinicId, string order)
    {
        var patients = Patients
            .Where(x => clinicId == 0 || x.ClinicId == clinicId)
            .AsQueryable();
        patients = order switch
        {
            "asc" => patients.OrderBy(x => x.DateOfBirth),
            "desc" => patients.OrderByDescending(x => x.DateOfBirth),
            _ => patients.OrderBy(x => x.LastName)
        };
        return patients.Select(x => _patientMapper.From(x)).ToList();
    }
}