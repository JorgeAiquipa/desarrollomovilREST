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

namespace WcfSrvCitasMedicas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CronogramaSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CronogramaSrv.svc or CronogramaSrv.svc.cs at the Solution Explorer and start debugging.
    public class CronogramaSrv : ICronogramaSrv
    {
        private Cronograma_atencionDAO dao = new Cronograma_atencionDAO();
        public String CrearCronograma(Cronograma_atencion cronogramaACrear)
        {
            String tmp_cronograma = "0";
            tmp_cronograma = dao.Crear(cronogramaACrear);
            return tmp_cronograma;
        }
    }
}
