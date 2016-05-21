using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfSrvCitasMedicas.Dominio
{
     [DataContract]
    public class Reserva
    {
        [DataMember]
        public int co_reserva { get; set; }
         [DataMember]
        public int co_cronograma { get; set; }
         [DataMember]
        public int co_paciente { get; set; }
        [DataMember]
        public string fe_reserva { get; set; }
        [DataMember]
        public string ho_reserva { get; set; }
        [DataMember]
        public string fe_cancela { get; set; }
        [DataMember]
        public int in_estado { get; set; }
    }
}
