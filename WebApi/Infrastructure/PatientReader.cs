using WebApi.Domain;
using WebApi.Mapper;

namespace WebApi.Infrastructure;

public class PatientReader : IPatientReader
{
    private readonly IFileReader _fileReader;
    private readonly ICsvMapper<Patient> _csvMapper;

    public PatientReader(IFileReader fileReader, ICsvMapper<Patient> csvMapper)
    {
        _fileReader = fileReader;
        _csvMapper = csvMapper;
    }

    public async Task<List<Patient>> Read()
    {
        var list = new List<Patient>();
        list.AddRange(await Read("patients-1.csv"));
        list.AddRange(await Read("patients-2.csv"));
        return list;
    }

    private async Task<List<Patient>> Read(string fileName)
    {
        var content = await _fileReader.GetContent(fileName);
        return content.Skip(1).Select(_csvMapper.From).ToList();
    }
}