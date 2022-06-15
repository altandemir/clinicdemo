using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}