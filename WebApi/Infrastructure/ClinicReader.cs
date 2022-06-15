using WebApi.Domain;
using WebApi.Extensions;
using WebApi.Mapper;

namespace WebApi.Infrastructure;

public class ClinicReader : IClinicReader
{
    private readonly IFileReader _fileReader;
    private readonly ICsvMapper<Clinic> _csvMapper;


    public ClinicReader(IFileReader fileReader
        , ICsvMapper<Clinic> csvMapper)
    {
        _fileReader = fileReader;
        _csvMapper = csvMapper;
    }

    public async Task<List<Clinic>> Read()
    {
        const string fileName = "clinics.csv";
        var content = await _fileReader.GetContent(fileName);
        return content.Skip(1).Select(_csvMapper.From).ToList();
    }
}