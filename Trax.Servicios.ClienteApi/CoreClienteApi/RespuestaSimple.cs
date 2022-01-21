using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Servicios.ClienteApi.CoreClienteApi
{
    public class RespuestaSimple
    {
        public RespuestaSimple()
        {

        }

        public short result { get; set; }
        public string mensaje { get; set; }
    }
}
