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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISedeSrv" in both code and config file together.
    [ServiceContract]
    public interface ISedeSrv
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Sedes", ResponseFormat = WebMessageFormat.Json)]
        Sede CrearSede(Sede sedeACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerSedes", ResponseFormat = WebMessageFormat.Json)]
        List<Sede> ObtenerSedes();

    }
}
