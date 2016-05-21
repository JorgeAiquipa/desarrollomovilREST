using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace WcfSrvCitasMedicas.Dominio
{
    [DataContract]
    public class Sede
    {
        [DataMember]
        public int co_sede { get; set; }
        [DataMember]
        public string de_sede { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}