using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;


namespace WcfSrvCitasMedicas.Persistencia
{
    public class MedicoDAO
    {
        public Medico Crear(Medico medicoACrear)
        {
            Medico medicoCreado = null;
            string sql = "INSERT INTO medico(de_nombreCompleto,co_especialidad,in_estado) VALUES (@de_nomb,@co_espe, 1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@de_nomb", medicoACrear.de_nombreCompleto));
                    com.Parameters.Add(new MySqlParameter("@co_espe", medicoACrear.co_especialidad));
 
                    com.ExecuteNonQuery();
                }
            }
            medicoCreado = ObtenerDescripcion(medicoACrear.de_nombreCompleto);
            return medicoCreado;
        }

        public Medico ObtenerDescripcion(string codigo)
        {
            Medico medicoEncontrado = null;
            string sql = "SELECT * FROM medico WHERE de_nombreCompleto=@cod";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@cod", codigo));
                    using (MySqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            medicoEncontrado = new Medico()
                            {

                                co_medico = Int16.Parse(resultado["co_medico"].ToString()),
                                de_nombreCompleto = (string)resultado["de_nombreCompleto"],
                                co_especialidad = Int16.Parse(resultado["co_especialidad"].ToString()),
                                in_estado = Int16.Parse(resultado["in_estado"].ToString())
                            };
                        }
                    }
                }
            }
            return medicoEncontrado;
        }


        public List<Medico> ListarMedicos()
        {
            List<Medico> Lista = new List<Medico>();
            string sql = "SELECT * FROM medico";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    MySqlDataReader dr = null;
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        Medico med = new Medico();
                        med.co_medico  = dr.GetInt16(0);
                        med.de_nombreCompleto  = dr.GetString(1);
                        med.co_especialidad = dr.GetInt16(2);
                        med.in_estado = dr.GetInt16(3);
                        Lista.Add(med);
                    }
                }
            }
            return Lista;
        }
    }
}