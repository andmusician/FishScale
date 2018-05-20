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

        //criar INSERT

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

            //MÉTODO QUE PEGA OS DADOS DE HD DA TABELA DE MONITORAÇÃO, CALCULA A PORCENTAGEM DE USO E INSERE EM UMA LISTA.
            List<double> dadosAlertaHD = new List<double>();
            
            using (SqlCommand command = new SqlCommand(SelectPorcentagemHD, conn1))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var dadosHD = new Alerta
                    {
                        AlertaHD = reader.GetDouble(0)
                    };

                    //dados.AlertaHD = reader.GetDouble(0); OBS: PODE SER UTILIZADO NO LUGAR DO BLOCO ACIMA.
                    dadosAlertaHD.Add(dadosHD.AlertaHD.Value);                    
                }
            }

            //MÉTODO QUE PEGA OS DADOS DE RAM DA TABELA DE MONITORAÇÃO, CALCULA A PORCENTAGEM DE USO E INSERE EM UMA LISTA.
            List<double> dadosAlertaRAM = new List<double>();

            using (SqlCommand command = new SqlCommand(SelectPorcentagemRAM, conn1))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var dadosRAM = new Alerta
                    {
                        AlertaRAM = reader.GetDouble(0)
                    };

                    dadosAlertaRAM.Add(dadosRAM.AlertaRAM.Value);
                }
            }
            
            for (int i = 0; i < dadosAlertaRAM.Count; i++)
            {
                if (dadosAlertaRAM[i] > dadosAlertaHD[i]) //Inserir Alerta HD Cliente pelo id do Cliente. 
                {
                    using (SqlCommand command = new SqlCommand("Insert into Alerta", conn1))
                    {
                        i = command.ExecuteNonQuery();
                    }                    
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
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        Hora = Convert.ToDateTime(reader["Hora"])
                    };

                    AlertasList.Add(Clientes);
                }

                conn1.Close();

                return AlertasList;
            }
        }

    }
}