using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FishScale.Models;


namespace FishScale.Repositorio
{
    public class ClienteRepositorio
    {
        private SqlConnection conn1;

        private void Connection()
        {
            string construtor = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn1 = new SqlConnection();
        }

        public bool AdicionarCliente(Cliente clienteObj)
        {
                
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirCliente", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QtdeMaquinas", clienteObj.QtdeMaquinas);
                command.Parameters.AddWithValue("@NomeCliente", clienteObj.NomeCliente);
                command.Parameters.AddWithValue("@AlertaHD", clienteObj.AlertaHD);
                command.Parameters.AddWithValue("@AlertaRAM", clienteObj.AlertaRam);

                conn1.Open();

                i = command.ExecuteNonQuery();

            }

            conn1.Close();

            return i >= 1;
        }

        public List<Cliente> ObterClientes()
        {
            Connection();

            List<Cliente> ClientesList = new List<Cliente>();

            using (SqlCommand command = new SqlCommand("ObterClientes", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;

                conn1.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente Clientes = new Cliente()
                    {
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        NomeCliente = Convert.ToString(reader["NomeCliente"]),
                        QtdeMaquinas = Convert.ToInt32(reader["QtdeMaquinas"]),
                        AlertaHD = Convert.ToDouble(reader["AlertaHD"]),
                        AlertaRam = Convert.ToDouble(reader["AlertaRAM"])
                    };

                    ClientesList.Add(Clientes);
                }

                conn1.Close();

                return ClientesList;
            }
        }

        public bool AtualizarCliente(Cliente clienteObj)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarCliente", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", clienteObj.ClienteID);
                command.Parameters.AddWithValue("@QtdeMaquinas", clienteObj.QtdeMaquinas);
                command.Parameters.AddWithValue("@NomeCliente", clienteObj.NomeCliente);
                command.Parameters.AddWithValue("@AlertaHD", clienteObj.AlertaHD);
                command.Parameters.AddWithValue("@AlertaRAM", clienteObj.AlertaRam);

                conn1.Open();

                i = command.ExecuteNonQuery();

            }

            conn1.Close();

            return i >= 1;
        }

        public bool ExcluirCliente(int id)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirClientePorId", conn1))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", id);                              

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