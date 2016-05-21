using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfSrvCitasMedicas.Dominio
{
    [DataContract]
    public class Especialidad
    {
        [DataMember]
        public int co_especialidad { get; set; }
        [DataMember]
        public string de_especialidad { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}