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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PacienteSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PacienteSrv.svc or PacienteSrv.svc.cs at the Solution Explorer and start debugging.
    public class PacienteSrv : IPacienteSrv
    {
        private PacienteDAO dao = new PacienteDAO();
        public Paciente CrearPaciente(Paciente pacienteACrear)
        {
            Paciente  tmp_paciente = null;
            tmp_paciente = dao.Obtener(pacienteACrear.nu_dni );
            if (tmp_paciente != null)
            {
                throw new WebFaultException<string>("Imposible Agregar Paciente", HttpStatusCode.Unauthorized);
            }

            tmp_paciente = dao.Crear(pacienteACrear);

            return tmp_paciente;
        }
    }
}
