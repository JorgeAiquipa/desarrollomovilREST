using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using WcfSrvCitasMedicas.Dominio; 

namespace WcfSrvCitasMedicas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservaSrv" in both code and config file together.
    [ServiceContract]
    public interface IReservaSrv
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        String CrearReserva(Reserva reservaACrear);
    }
}
