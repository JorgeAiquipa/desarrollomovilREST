using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfSrvCitasMedicas.Persistencia
{
    public class ConexionUtils
    {
        public static string Cadena
        {
            get
            {
                return "server=localhost; database=bd_citasclinica; user id=marsa; password=sebluc2016";
            }
        }
    }
}