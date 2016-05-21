using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfSrvCitasMedicas.Dominio;
using WcfSrvCitasMedicas.Persistencia;
using System.Net;
using System.Messaging;
using System.ServiceModel.Web;


namespace WcfSrvCitasMedicas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SedeSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SedeSrv.svc or SedeSrv.svc.cs at the Solution Explorer and start debugging.
    public class SedeSrv : ISedeSrv
    {
        private SedeDAO dao = new SedeDAO();
        public Sede CrearSede(Sede sedeACrear)
        {
            Sede tmp_sede = null;
            tmp_sede = dao.ObtenerDescripcion(sedeACrear.de_sede);
            if (tmp_sede != null)
            {
                throw new WebFaultException<string>("Imposible Agregar sede", HttpStatusCode.Unauthorized);
            }

            tmp_sede = dao.Crear(sedeACrear);

            return tmp_sede;
        }

        public List<Sede> ObtenerSedes()
        {
            return dao.ListarSedes();
        }

       }
}
