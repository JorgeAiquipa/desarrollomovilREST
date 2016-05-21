using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfSrvCitasMedicas.Dominio
{
    [DataContract]
    public class Medico
    {
        [DataMember]
        public int co_medico { get; set; }
        [DataMember]
        public string de_nombreCompleto { get; set; }
        [DataMember]
        public int co_especialidad { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}