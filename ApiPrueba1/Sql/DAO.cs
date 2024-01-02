using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ApiPrueba1.Sql
{
    public class DAO
    {
        private static string conString = "Server=localhost; Database=@bbdd; Uid=@user; Pwd=@Password;";
        private static MySqlConnection Connection = null;
        private static DAO accessMysql=null;
        private static string Bbdd { get; set; } = null;
        private static string user {  get; set; } = null;
        private static string password { get; set; } = null;

        public static DAO instance(string bbdd, string user, string password)
        {
            try
            {
                if(accessMysql != null)
                {
                    if(DAO.Bbdd!=bbdd || DAO.user!=user || DAO.password != password)
                    {
                        
                        Connection.Close();
                        createInstance(bbdd, user, password);   

                        
                    }

                }
                else
                {
                    createInstance(bbdd, user, password);
                }
            }
            catch(Exception e) {
                throw new Exception("Error al instanciar connection " + e.Message);
            }
            return accessMysql;
        }

        private static void createInstance(string bbdd, string user, string password)
        {
            accessMysql = new DAO(bbdd, user, password);
            DAO.user = user;
            DAO.password = password;
            DAO.Bbdd = bbdd;
        }

        private DAO(string bbdd, string user, string password)
        {
            try
            {
                var url = DAO.conString.Replace("@bbdd", bbdd);
                url = url.Replace("@user", user);
                url = url.Replace("@Password", password);
                Connection = new MySql.Data.MySqlClient.MySqlConnection();
                Connection.ConnectionString = url;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Boolean check()
        {
            if(Connection != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MySqlConnection GetConnection() { return Connection; }   
    }
}