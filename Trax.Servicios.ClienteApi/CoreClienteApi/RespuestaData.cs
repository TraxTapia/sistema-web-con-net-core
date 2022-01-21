using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Servicios.ClienteApi.CoreClienteApi
{
    public class RespuestaData<T>
    {
        public RespuestaData()
        {

        }

        public RespuestaSimple Respuesta { get; set; }
        public T Datos { get; set; }
    }
}
