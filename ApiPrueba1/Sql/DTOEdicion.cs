using ApiPrueba1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class DTOEdicion : GetConnectionDao
    {

        public DTOEdicion() { }

        public List<Edicion> GetEdiciones()
        {
            var listaEdiciones = new List<Edicion>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getEdiciones()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var edicion = new Edicion();
                    edicion.Id = reader.GetFieldValue<int>(0);
                    edicion.Nombre = reader.GetFieldValue<string>(1);
                    listaEdiciones.Add(edicion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaEdiciones;
        }

        public bool postEdicion(string name)
        {
            var numberOfColumnsAffected = 0;
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "CALL postEdicion(@name)";
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