using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;

namespace WcfSrvCitasMedicas.Persistencia
{
    public class ReservaDAO
    {
        public String Crear(Reserva reservaACrear)
        {
            string sql = "INSERT INTO reserva(co_cronograma,co_paciente,fe_reserva,ho_reserva,fe_cancela,in_estado) VALUES (@co_cro,@co_pac,@fe_res,@ho_res,@fe_can,1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@co_cro", reservaACrear.co_cronograma ));
                    com.Parameters.Add(new MySqlParameter("@co_pac", reservaACrear.co_paciente));
                    com.Parameters.Add(new MySqlParameter("@fe_res", reservaACrear.fe_reserva));
                    com.Parameters.Add(new MySqlParameter("@ho_res", reservaACrear.ho_reserva));
                    com.Parameters.Add(new MySqlParameter("@fe_can", reservaACrear.fe_cancela));
                    com.ExecuteNonQuery();
                }
            }
            return "1";
        }
    }
}