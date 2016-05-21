using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfSrvCitasMedicas.Dominio
{
      [DataContract]
    public class Cronograma_atencion
    {
        [DataMember]
        public int co_cronograma { get; set; }
        [DataMember]
        public int co_sede { get; set; }
        [DataMember]
        public int co_medico { get; set; }
        [DataMember]
        public String fe_atencion { get; set; }
        [DataMember]
        public String ho_atencion { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}