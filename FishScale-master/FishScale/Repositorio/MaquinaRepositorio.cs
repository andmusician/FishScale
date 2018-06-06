using FishScale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FishScale.Repositorio
{
    public class MaquinaRepositorio
    {
        private SqlConnection conn1;

        private void Connection()
        {
            string construtor = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn1 = new SqlConnection(construtor);
        }

        public bool AdicionarMaquina(Maquina maquinaObj)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirMaquina", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SistemaOperacional", maquinaObj.SistemaOperacional);
                command.Parameters.AddWithValue("@ClienteID", maquinaObj.ClienteID);                

                conn1.Open();

                i = command.ExecuteNonQuery();

            }

            conn1.Close();

            return i >= 1;
        }

        public List<Maquina> ObterMaquinas()
        {
            Connection();

            List<Maquina> MaquinasList = new List<Maquina>();

            using (SqlCommand command = new SqlCommand("ObterMaquinas", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;

                conn1.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Maquina Maquinas = new Maquina()                    
                    {
                        MaquinaID = Convert.ToInt32(reader["MaquinaID"]),
                        SistemaOperacional = Convert.ToString(reader["SistemaOperacional"]),
                        ClienteID = Convert.ToInt32(reader["ClienteID"])                        
                    };

                    MaquinasList.Add(Maquinas);
                }

                conn1.Close();

                return MaquinasList;
            }
        }

        public bool AtualizarMaquinas(Maquina maquinaObj)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarMaquina", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaquinaID", maquinaObj.MaquinaID);
                command.Parameters.AddWithValue("@SistemaOperacional", maquinaObj.SistemaOperacional);
                command.Parameters.AddWithValue("@ClienteID", maquinaObj.ClienteID);
                

                conn1.Open();

                i = command.ExecuteNonQuery();

            }

            conn1.Close();

            return i >= 1;
        }

        public bool ExcluirMaquina(int id)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirMaquinaPorId", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaquinaID", id);

                conn1.Open();

                i = command.ExecuteNonQuery();

            }

            conn1.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }

    }
}