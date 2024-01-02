using ApiPrueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class DTOAutor : GetConnectionDao
    {
        public DTOAutor() { }

        public List<Autor> getAutores()
        {
            var listaAutores = new List<Autor>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getAutores()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var autor = new Autor();
                    autor.Id = reader.GetFieldValue<int>(0);
                    autor.Nombre = reader.GetFieldValue<string>(1);
                    listaAutores.Add(autor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
            return listaAutores;
        }
    }
}