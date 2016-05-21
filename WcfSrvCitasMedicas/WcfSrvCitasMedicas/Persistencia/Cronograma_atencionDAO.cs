using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfSrvCitasMedicas.Dominio;
using MySql.Data.MySqlClient;


namespace WcfSrvCitasMedicas.Persistencia
{
    public class Cronograma_atencionDAO
    {
        public String Crear(Cronograma_atencion cronogramaACrear)
        {            
            string sql = "INSERT INTO cronograma_atencion(co_sede,co_medico,fe_atencion,ho_atencion,in_estado) VALUES (@co_sed,@co_med,@fe_ate,@ho_ate,1)";
            using (MySqlConnection con = new MySqlConnection(ConexionUtils.Cadena))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    com.Parameters.Add(new MySqlParameter("@co_sed", cronogramaACrear.co_sede));
                    com.Parameters.Add(new MySqlParameter("@co_med", cronogramaACrear.co_medico));
                    com.Parameters.Add(new MySqlParameter("@fe_ate", cronogramaACrear.fe_atencion));
                    com.Parameters.Add(new MySqlParameter("@ho_ate", cronogramaACrear.ho_atencion));
                    com.ExecuteNonQuery();
                }
            }            
            return "1";
        }
    }
}