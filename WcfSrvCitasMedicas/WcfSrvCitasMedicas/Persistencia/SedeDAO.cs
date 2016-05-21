using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;

namespace WcfSrvCitasMedicas.Persistencia
{
    public class SedeDAO
    {
        public Sede Crear(Sede sedeACrear)
        {
            Sede sedeCreado = null;
            string sql = "INSERT INTO sede(de_sede,in_estado) VALUES (@de_sede, 1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@de_sede", sedeACrear.de_sede));
                    com.ExecuteNonQuery();
                }
            }
            sedeCreado = ObtenerDescripcion(sedeACrear.de_sede);
            return sedeCreado;
        }

        public Sede ObtenerDescripcion(string codigo)
        {
            Sede sedeEncontrado = null;
            string sql = "SELECT * FROM sede WHERE de_sede=@cod";
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
                            sedeEncontrado = new Sede()
                            {

                                co_sede = Int16.Parse(resultado["co_sede"].ToString()),
                                de_sede = (string)resultado["de_sede"],
                                in_estado = Int16.Parse(resultado["in_estado"].ToString())
                            };
                        }
                    }
                }
            }
            return sedeEncontrado;
        }


        public List<Sede> ListarSedes()
        {
            List<Sede> Lista = new List<Sede>();
            string sql = "SELECT * FROM sede";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    MySqlDataReader  dr = null;
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        Sede sed = new Sede();
                        sed.co_sede = dr.GetInt16(0);
                        sed.de_sede = dr.GetString(1);
                        sed.in_estado  = dr.GetInt16(2);
                        Lista.Add(sed);
                    }
                }
            }
            return Lista;
        }

    }
}