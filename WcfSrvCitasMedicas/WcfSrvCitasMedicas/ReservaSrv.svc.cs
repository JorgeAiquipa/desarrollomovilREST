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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservaSrv" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReservaSrv.svc or ReservaSrv.svc.cs at the Solution Explorer and start debugging.
    public class ReservaSrv : IReservaSrv
    {
        private ReservaDAO dao = new ReservaDAO();
        public String CrearReserva(Reserva reservaACrear)
        {
            String tmp_reserva = "0";
            tmp_reserva = dao.Crear(reservaACrear);
            return tmp_reserva;
        }
    }
}
