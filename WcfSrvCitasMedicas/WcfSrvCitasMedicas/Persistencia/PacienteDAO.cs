using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;


namespace WcfSrvCitasMedicas.Persistencia
{
    public class PacienteDAO
    {
        public Paciente Crear(Paciente pacienteACrear)
        {
            Paciente pacienteCreado = null;
            string sql = "INSERT INTO paciente(de_nombreCompleto,nu_dni,de_clave,in_estado) VALUES (@de_nomb,@dni,@clave, 1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@de_nomb", pacienteACrear.de_nombreCompleto));
                    com.Parameters.Add(new MySqlParameter("@dni", pacienteACrear.nu_dni));
                    com.Parameters.Add(new MySqlParameter("@clave", pacienteACrear.de_clave ));

                    com.ExecuteNonQuery();
                }
            }
            pacienteCreado = Obtener(pacienteACrear.nu_dni );
            return pacienteCreado;
        }

        public Paciente Obtener(string codigo)
        {
            Paciente pacienteEncontrado = null;
            string sql = "SELECT * FROM paciente WHERE nu_dni=@cod";
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
                            pacienteEncontrado = new Paciente()
                            {

                                co_paciente = Int16.Parse(resultado["co_paciente"].ToString()),
                                de_nombreCompleto = (string)resultado["de_nombreCompleto"],
                                nu_dni = (string)resultado["nu_dni"],
                                de_clave = (string)resultado["de_clave"],
                                in_estado = Int16.Parse(resultado["in_estado"].ToString())
                            };
                        }
                    }
                }
            }
            return pacienteEncontrado;
        }
    }
}