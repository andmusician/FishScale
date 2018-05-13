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
    }
}