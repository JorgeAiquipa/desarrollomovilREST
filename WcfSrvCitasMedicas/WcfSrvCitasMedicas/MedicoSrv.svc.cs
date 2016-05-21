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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MedicoSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MedicoSrv.svc or MedicoSrv.svc.cs at the Solution Explorer and start debugging.
    public class MedicoSrv : IMedicoSrv
    {
        private MedicoDAO dao = new MedicoDAO();
        public Medico CrearMedico(Medico medicoACrear)
        {
            Medico tmp_medico = null;
            tmp_medico = dao.ObtenerDescripcion(medicoACrear.de_nombreCompleto);
            if (tmp_medico != null)
            {
                throw new WebFaultException<string>("Imposible Agregar Medico", HttpStatusCode.Unauthorized);
            }

            tmp_medico = dao.Crear(medicoACrear);

            return tmp_medico;
        }

        public List<Medico> ObtenerMedicos()
        {
            return dao.ListarMedicos();
        }
    }
}
