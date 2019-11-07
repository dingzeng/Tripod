using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Tripod.Service.System.DAL
{
    public class BaseDAO
    {
        private IDbConnection GetConnection()
        {
            return new MySqlConnection("database=sblpro_test;server=192.168.215.201;uid=root;pwd=Admin123!");
        }
        public T Run<T>(Func<IDbConnection,T> func)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                return func(conn);
            }
        }
    }
}