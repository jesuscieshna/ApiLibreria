using ApiPrueba1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class DTOTema : GetConnectionDao
    {

        public DTOTema() { }   

        public List<Tema> GetTemas()
        {
            var listaTemas = new List<Tema>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call gettemas()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var t = new Tema();
                    t.Id = reader.GetFieldValue<int>(0);
                    t.Name = reader.GetFieldValue<string>(1);
                    listaTemas.Add(t);
                }
            }catch (Exception ex) { 
                throw new Exception(ex.Message);  
            }finally { connection.Close(); }
            return listaTemas;
        }

        public bool PostTema(string name)
        {
            var numberOfColumnsAffected = 0;
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "CALL postTema(@name)";
                    
                    cmd.Parameters.AddWithValue("@name", name);  // Ensure null values are handled
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