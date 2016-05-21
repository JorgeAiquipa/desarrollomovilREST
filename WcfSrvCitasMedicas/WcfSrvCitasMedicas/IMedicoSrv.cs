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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMedicoSrv" in both code and config file together.
    [ServiceContract]
    public interface IMedicoSrv
    {
        [OperationContract]        
        [WebInvoke(Method = "POST", UriTemplate = "Medicos", ResponseFormat = WebMessageFormat.Json)]
        Medico CrearMedico(Medico medicoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerMedicos", ResponseFormat = WebMessageFormat.Json)]
        List<Medico> ObtenerMedicos();

    }
}
