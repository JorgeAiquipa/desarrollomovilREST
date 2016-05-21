using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using WcfSrvCitasMedicas.Dominio;
 
namespace WcfSrvCitasMedicasTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearEspecialidadOK()
        {    
            string postData = "{\"de_especialidad\":\"Cirujano\",\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/EspecialidadSrv.svc/Especialidades");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string especialidadJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Especialidad especialidadCreada = js.Deserialize<Especialidad>(especialidadJson);
            Assert.AreEqual("Cirujano", especialidadCreada.de_especialidad);
            Assert.AreEqual(1, especialidadCreada.in_estado);
        }

        [TestMethod]
        public void CrearSedeOK()
        {
            string postData = "{\"de_sede\":\"SAN MIGUEL\",\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/SedeSrv.svc/Sedes");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string sedeJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Sede sedeCreada = js.Deserialize<Sede>(sedeJson);
            Assert.AreEqual("CHORRILLOS", sedeCreada.de_sede);
            Assert.AreEqual(1, sedeCreada.in_estado);
        }

        [TestMethod]
        public void CrearMedicoOK()
        {
            string postData = "{\"de_nombreCompleto\":\"Jorge Aiquipa\",\"co_especialidad\":1,\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/MedicoSrv.svc/Medicos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string medicoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoCreada = js.Deserialize<Medico>(medicoJson);
            Assert.AreEqual("Jorge Aiquipa", medicoCreada.de_nombreCompleto);
            Assert.AreEqual(1, medicoCreada.co_especialidad);
            Assert.AreEqual(1, medicoCreada.in_estado);
        }

        [TestMethod]
        public void CrearCronogramaOK()
        {
            string postData = "{\"co_sede\":1,\"co_medico\":1,\"fe_atencion\":\"2011-06-02\",\"ho_atencion\":\"12:24:34\",\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/CronogramaSrv.svc/Cronogramas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            String cronogramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            String cronogramaCreada = js.Deserialize<String>(cronogramaJson);
            Assert.AreEqual("1", cronogramaCreada);            
        }

        

        [TestMethod]
        public void CrearPacienteOK()
        {
            string postData = "{\"de_nombreCompleto\":\"Jorge Aiquipa\",\"nu_dni\":\"09779646\",\"de_clave\":\"#4#$67*278\",\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/PacienteSrv.svc/Pacientes");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string pacienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Paciente pacienteCreada = js.Deserialize<Paciente>(pacienteJson);
            Assert.AreEqual("Jorge Aiquipa", pacienteCreada.de_nombreCompleto);
            Assert.AreEqual("09779646", pacienteCreada.nu_dni );
            Assert.AreEqual(1, pacienteCreada.in_estado);
        }


        [TestMethod]
        public void CrearReservaOK()
        {
            string postData = "{\"co_cronograma\":1,\"co_paciente\":1,\"fe_reserva\":\"2011-06-02\",\"ho_reserva\":\"12:24:34\",\"fe_cancela\":\"2011-06-06\",\"in_estado\":1}";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:64181/ReservaSrv.svc/Reservas");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            String reservaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            String reservaCreada = js.Deserialize<String>(reservaJson);
            Assert.AreEqual("1", reservaCreada);    
        }

    }
}
