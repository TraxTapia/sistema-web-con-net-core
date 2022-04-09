using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Api;
using Models.Models.Request;
using Models.Models.SistemaWeb;
using System.Threading.Tasks;
using Trax.Servicios.ClienteApi.CoreClienteApi;
using TRAX.SistemaTrax.Web.App_Code;

namespace TRAX.SistemaTrax.Web.Controllers
{
 
    public class LoginController : Controller
    {
        private string serviceApi = ReadConfig.ReadKey("ServiciosWeb", "urlServices");
        ServiceCall _service = new ServiceCall();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index (RequestUsuario request)
        {
            RespuestaSimple respuesta = new RespuestaSimple(); 
            try
            {

                RespuestaSimple _OperationResult = new RespuestaSimple();
                ServiceCall _coreService = new ServiceCall();
                //DatosToken _tokenCore = new DatosToken();
                //_tokenCore.user = ReadConfig.ReadKey("ServicioProvedores", "user");
                //_tokenCore.password = ReadConfig.ReadKey("ServicioProvedores", "password");

                RequestTknUsuario requestUser = new RequestTknUsuario()
                {
                    Usuario = request.Correo,
                    Password = request.Contrasena
                };
                //_OperationResult = await _coreService.CallPostSimple<DatosToken>(_tokenCore, apiUrlCoreApi, ReadConfig.ReadKey("ServicioProvedores", "ServicioToken"));
                //HttpContext.Session.SetString("AppTokenReference", _OperationResult.mensaje);
                _OperationResult = await _coreService.CallPostSimple<RequestTknUsuario>(requestUser, serviceApi, ReadConfig.ReadKey("AppServices", "ServicioLoginUsuario"), _OperationResult.mensaje);
                HttpContext.Session.SetString("AppToken", _OperationResult.mensaje);
                HttpContext.Session.SetString("validarToken", "1");
                if (_OperationResult.result != 1)
                {

                    ViewBag.Error = "Usuario o contraseña Incorrecta";
                    return View();

                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
