using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfSrvCitasMedicas.Dominio
{
     [DataContract]
    public class Paciente
    {
        [DataMember]
        public int co_paciente { get; set; }
        [DataMember]
        public string de_nombreCompleto { get; set; }
        [DataMember]
        public string nu_dni { get; set; }
        [DataMember]
        public string de_clave { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}