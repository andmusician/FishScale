using FishScale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FishScale.Repositorio
{
    public class AlertaRepositorio
    {
        private const string SelectPorcentagemHD = "SELECT (UsedHD / TotalHD) FROM Monitoracao";

        private const string SelectPorcentagemRAM = "SELECT (UsedRAM / TotalRAM) FROM Monitoracao";

        private const string SelectAlertaHDCliente = "SELECT AlertaHD FROM Cliente";

        private const string SelectAlertaRAMCliente = "SELECT AlertaRAM FROM Cliente";

        private SqlConnection conn1;

        private void Connection()
        {
            string construtor = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn1 = new SqlConnection(construtor);
        }

        private void InserirAlertasNaTabela()
        {
            Connection();

            conn1.Open();

            //double[] dadosAlertaHD = new double[];
            List<double> dadosAlertaHD = new List<double>();
            
            using (SqlCommand command = new SqlCommand(SelectPorcentagemHD, conn1))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var dados = new Alerta
                    {
                        AlertaHD = reader.GetDouble(0)
                    };

                    //dados.AlertaHD = reader.GetDouble(0);
                    dadosAlertaHD.Add(dados.AlertaHD);                    
                }
            }
        }

        public List<Alerta> ObterAlertas()
        {
            Connection();

            List<Alerta> AlertasList = new List<Alerta>();

            using (SqlCommand command = new SqlCommand("ObterAlertas", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;

                conn1.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Alerta Clientes = new Alerta()
                    {
                        AlertaID = Convert.ToInt32(reader["AlertaID"]),
                        AlertaHD = Convert.ToDouble(reader["AlertaHD"]),
                        AlertaRAM = Convert.ToDouble(reader["AlertaRAM"]),
                        MaquinaID = Convert.ToInt32(reader["MaquinaID"]),
                        ClienteID = Convert.ToInt32(reader["ClienteID"])
                    };

                    AlertasList.Add(Clientes);
                }

                conn1.Close();

                return AlertasList;
            }
        }

    }
}