using Microsoft.AspNetCore.Mvc;

namespace TRAX.SistemaTrax.Web.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
