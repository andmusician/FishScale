using FishScale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FishScale.Repositorio
{
    public class MonitoracaoRepositorio
    {
        private SqlConnection conn1;

        private void Connection()
        {
            string construtor = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn1 = new SqlConnection(construtor);
        }

        public List<Monitoracao> ObterMonitoracao()
        {
            Connection();

            List<Monitoracao> MonitoracaoList = new List<Monitoracao>();

            using (SqlCommand command = new SqlCommand("ObterMonitoracaoDesc", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;

                conn1.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Monitoracao Monitoracao = new Monitoracao()
                    {
                        MonitoraID = Convert.ToInt32(reader["MonitoraID"]),
                        TotalRAM = Convert.ToDouble(reader["TotalRAM"]),
                        TotalHD = Convert.ToDouble(reader["TotalHD"]),
                        UsedHD = Convert.ToDouble(reader["UsedHD"]),
                        UsedRAM = Convert.ToDouble(reader["UsedRAM"]),
                        Hora = Convert.ToDateTime(reader["Hora"]),
                        MaquinaID = Convert.ToInt32(reader["MaquinaID"]),                        
                        ClienteID = Convert.ToInt32(reader["ClienteID"])
                    };

                    MonitoracaoList.Add(Monitoracao);
                }

                conn1.Close();

                return MonitoracaoList;
            }
        }
    }
}