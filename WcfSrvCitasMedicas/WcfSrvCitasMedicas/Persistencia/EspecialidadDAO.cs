using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;

namespace WcfSrvCitasMedicas.Persistencia
{
    public class EspecialidadDAO
    {
        public Especialidad Crear(Especialidad especialidadACrear)
        {
            Especialidad especialidadCreado = null;
            string sql = "INSERT INTO especialidad(de_especialidad,in_estado) VALUES (@de_espe, 1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@de_espe", especialidadACrear.de_especialidad));
                    com.ExecuteNonQuery();
                }
            }
            especialidadCreado = ObtenerDescripcion(especialidadACrear.de_especialidad);
            return especialidadCreado;
        }

        public Especialidad ObtenerDescripcion(string codigo)
        {
            Especialidad especialidadEncontrado = null;
            string sql = "SELECT * FROM Especialidad WHERE de_especialidad=@cod";
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
                            especialidadEncontrado = new Especialidad()
                            {
                    
                                co_especialidad = Int16.Parse(resultado["co_especialidad"].ToString()),
                                de_especialidad = (string)resultado["de_especialidad"],
                                in_estado = Int16.Parse(resultado["in_estado"].ToString())
                            };
                        }
                    }
                }
            }
            return especialidadEncontrado;
        }

    }
}