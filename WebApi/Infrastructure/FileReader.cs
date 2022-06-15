namespace WebApi.Infrastructure;

public class FileReader : IFileReader
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;

    public FileReader(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
    }

    public async Task<string[]> GetContent(string fileName)
    {
        var contentPath = _configuration["ContentPath"];
        var contentRootPath = _webHostEnvironment.ContentRootPath;
        var path = Path.Combine(contentRootPath, contentPath, fileName);
        return await File.ReadAllLinesAsync(path);
    }
}