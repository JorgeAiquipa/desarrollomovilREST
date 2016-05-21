using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfSrvCitasMedicas.Dominio;
using WcfSrvCitasMedicas.Persistencia;
using System.Net;
using System.Messaging;

namespace WcfSrvCitasMedicas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EspecialidadSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EspecialidadSrv.svc or EspecialidadSrv.svc.cs at the Solution Explorer and start debugging.
    public class EspecialidadSrv : IEspecialidadSrv
    {
        private EspecialidadDAO dao = new EspecialidadDAO();
        public Especialidad CrearEspecialidad(Especialidad especialidadACrear)
        {
            Especialidad tmp_especialidad = null;
            tmp_especialidad = dao.ObtenerDescripcion(especialidadACrear.de_especialidad);
            if (tmp_especialidad != null)
            {
                throw new WebFaultException<string>("Imposible Agregar especialidad", HttpStatusCode.Unauthorized);
            }

            tmp_especialidad = dao.Crear(especialidadACrear);
            
            return tmp_especialidad;
        }
    }
}
