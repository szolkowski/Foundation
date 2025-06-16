namespace Foundation.Features.Hangfire;

[Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
[Route("[controller]")]
public class HangfireCmsController : Controller
{
    [Route("[action]")]
    public ActionResult Index()
    {
        return View();
    }
}