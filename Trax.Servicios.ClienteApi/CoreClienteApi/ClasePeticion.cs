using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Servicios.ClienteApi.CoreClienteApi
{
    public class ClasePeticion<T>
    {
        public ClasePeticion()
        {

        }

        public T Clase { get; set; }
        public bool Transaccionalidad { get; set; }
        public string Token { get; set; }
    }
}
