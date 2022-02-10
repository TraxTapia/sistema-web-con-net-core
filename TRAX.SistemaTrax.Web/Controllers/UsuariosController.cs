using Microsoft.AspNetCore.Mvc;
using Models.Models.Request;
using Models.Models.SistemaWeb;
using System;
using System.Threading.Tasks;
using Trax.Servicios.ClienteApi.CoreClienteApi;
using TRAX.SistemaTrax.Web.App_Code;

namespace TRAX.SistemaTrax.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private string serviceApi = ReadConfig.ReadKey("ServiciosWeb", "urlServices");
        //private string recursoApiAgregarUsuario = ReadConfig.ReadKey("ServiciosWeb", "urlServices");
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AgregarUsuarios(RequestUsuario request)
        {
            RespuestaSimple respose = new RespuestaSimple();
            ServiceCall _service = new ServiceCall();
            try
            {
                //Usuarios addUsuario = new Usuarios()
                //{
                //    Nombre = request.Nombre.Trim(),
                //    ApellidoPaterno = request.ApellidoPaterno.Trim(),
                //    ApellidoMaterno = request.ApellidoMaterno.Trim(),
                //    Correo = request.Correo.Trim(),
                //    Contrasena = request.Contrasena,
                //    IdRol = request.IdRol

                //};
                ClasePeticion<RequestUsuario> peticion = new ClasePeticion<RequestUsuario>();
                peticion.Clase = request;

                respose = await _service.CallPostSimple<ClasePeticion<RequestUsuario>> (peticion, serviceApi, ReadConfig.ReadKey("ServiciosWeb", "apinuevoUsuario"));

            }
            catch (Exception ex)
            {
                return Json(new { mensaje ="Ocurrio un error al agregar el registro "+ ex.Message, success = 500 });
            }

            return Json(new { mensaje = "Se creo el registro correctamente", success = 200  });

        }

    }
}
