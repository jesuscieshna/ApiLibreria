using ApiPrueba1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class DTOFormato: GetConnectionDao
    {
        public DTOFormato() { }

        public List<Formato> GetFormatos()
        {
            var listaFormato = new List<Formato>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getFormatos()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var formato = new Formato();
                    formato.Id = reader.GetFieldValue<int>(0);
                    formato.Nombre = reader.GetFieldValue<string>(1);
                    listaFormato.Add(formato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaFormato;
        }

        public bool PostFormato(string name)
        {
            var numberOfColumnsAffected = 0;
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "CALL postFormato(@name)";
                    cmd.Parameters.AddWithValue("@name", name);
                    connection.Open();
                    numberOfColumnsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("MySQL exception: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return numberOfColumnsAffected > 0;
        }
    }
}