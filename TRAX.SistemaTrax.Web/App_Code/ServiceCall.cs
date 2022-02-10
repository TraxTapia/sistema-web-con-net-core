using System;
using System.Threading.Tasks;
using Trax.Servicios.ClienteApi.CoreClienteApi;

namespace TRAX.SistemaTrax.Web.App_Code
{
    public class ServiceCall
    {
        public async Task<RespuestaData<T1>> CallPost<T1, T2>(T2 Entrada, string UrlApi, string metodo, string Token)
        {

            RespuestaData<T1> response = new RespuestaData<T1>();
            try
            {
                ClasePeticion<T2> peticion = new ClasePeticion<T2>();
                ClienteRest<RespuestaData<T1>> cliente = new ClienteRest<RespuestaData<T1>>();
                peticion.Clase = Entrada;
                peticion.Token = Token;
                response = await cliente.LLamarServicioPostGeneral<ClasePeticion<T2>>(UrlApi, metodo, peticion);

            }
            catch (Exception ex)
            {
                response.Respuesta.mensaje = ex.Message.ToString();
            }
            return response;


        }
        public async Task<RespuestaSimple> CallPostSimple<T2>(T2 Entrada, string UrlApi, string metodo, string Token)
        {

            RespuestaSimple respuesta = new RespuestaSimple();
            try
            {
                ClasePeticion<T2> peticion = new ClasePeticion<T2>();
                ClienteRest<RespuestaSimple> cliente = new ClienteRest<RespuestaSimple>();
                peticion.Clase = Entrada;
                peticion.Token = Token;
                respuesta = await cliente.LLamarServicioPostGeneral<ClasePeticion<T2>>(UrlApi, metodo, peticion);

            }
            catch (Exception ex)
            {
                respuesta.mensaje = ex.Message.ToString();
            }
            return respuesta;


        }
        //SE PUEDE USAR PARA RESPUESTA SIMPLE SIN TOKEN

        public async Task<RespuestaSimple> CallPostSimple<T2>(T2 Entrada, string UrlApi, string metodo)
        {

            RespuestaSimple respuesta = new RespuestaSimple();
            try
            {

                ClienteRest<RespuestaSimple> cliente = new ClienteRest<RespuestaSimple>();
                respuesta = await cliente.LLamarServicioPostGeneral<T2>(UrlApi, metodo, Entrada);
            }
            catch (Exception ex)
            {
                respuesta.mensaje = ex.Message.ToString();
            }
            return respuesta;
        }
        //pasamos cualquier tipo de entrada y de salida
        public async Task<T1> CallPostGeneral<T1, T2>(T2 Entrada, string UrlApi, string metodo)
        {

            T1 respuesta = default(T1);
            try
            {
                ClienteRest<T1> cliente = new ClienteRest<T1>();
                respuesta = await cliente.LLamarServicioPostGeneral<T2>(UrlApi, metodo, Entrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}
