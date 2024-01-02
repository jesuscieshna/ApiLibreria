using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class GetConnectionDao
    {

        private DAO accessMysql;
        protected MySqlConnection connection;

        protected GetConnectionDao()
        {
            try
            {
                accessMysql = DAO.instance("libreria", "root","");
                connection = accessMysql.GetConnection();

            }catch (Exception ex)
            {
                throw new Exception("error al crear connection en getConnection");

            }
        }
    }
}