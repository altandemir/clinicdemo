using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Infrastructure;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicsController : Controller
{
    private readonly ILogger<ClinicsController> _logger;
    private readonly IApplicationContext _applicationContext;

    public ClinicsController(ILogger<ClinicsController> logger
        , IApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
    }

    [Route("Clinics")]
    public async Task<IActionResult> GetClinics()
    {
        try
        {
            _logger.LogEnter();
            return Ok(_applicationContext.GetClinics());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message,"Error getting clinics");
            return StatusCode(500);
        }
        finally
        {
            _logger.LogExit();
        }
    }

    [Route("Patients")]
    public async Task<IActionResult> GetPatients(int clinicId, string order)
    {
        try
        {
            _logger.LogEnter();
            return Ok(_applicationContext.GetPatients(clinicId, order));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting patients");
            return StatusCode(500);
        }
        finally
        {
            _logger.LogExit();
        }
    }
}