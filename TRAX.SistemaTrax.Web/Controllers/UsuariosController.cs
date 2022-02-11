using Microsoft.AspNetCore.Mvc;
using Models.Models.Request;
using Models.Models.Response;
using Models.Models.SistemaWeb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trax.Servicios.ClienteApi.CoreClienteApi;
using TRAX.SistemaTrax.Web.App_Code;

namespace TRAX.SistemaTrax.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private string serviceApi = ReadConfig.ReadKey("ServiciosWeb", "urlServices");
        ServiceCall _service = new ServiceCall();
        //private string recursoApiAgregarUsuario = ReadConfig.ReadKey("ServiciosWeb", "urlServices");
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AgregarUsuarios(RequestUsuario request)
        {
            RespuestaSimple respose = new RespuestaSimple();

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

                respose = await _service.CallPostSimple<ClasePeticion<RequestUsuario>>(peticion, serviceApi, ReadConfig.ReadKey("ServiciosWeb", "apinuevoUsuario"));

            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error al agregar el registro " + ex.Message, success = 500 });
            }

            return Json(new { mensaje = "Se creo el registro correctamente", success = 200 });

        }
        [HttpGet]
        public async Task<JsonResult> ObtenerUsuarios()
        {
            RespuestaData<List<ListaUsuariosResponse>> _result = new RespuestaData<List<ListaUsuariosResponse>>();
            RespuestaSimple _respuesta = new RespuestaSimple();
            List<ListaUsuariosResponse> _listUsers = new List<ListaUsuariosResponse>();
            try
            {
                ClienteRest<RespuestaData<List<ListaUsuariosResponse>>> cliente = new ClienteRest<RespuestaData<List<ListaUsuariosResponse>>>();


                _result = await cliente.LLamarServicioSimple(serviceApi, ReadConfig.ReadKey("ServiciosWeb", "getUsuarios"));
                if (_result != null)
                {
                    _listUsers = _result.Datos;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error durante la busqueda " + ex.Message, success = 500 });

            }
            return Json(new { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100, draw = true, recordsFiltered = 100, recordsTotal = 100, data = _listUsers,suceess=true});


        }
    }
}
