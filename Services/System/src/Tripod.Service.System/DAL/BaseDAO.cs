using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Tripod.Service.System.DAL
{
    public class BaseDAO<TEntity> where TEntity : class
    {
        static BaseDAO()
        {
            // eg:user_id -> UserId
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        private IDbConnection GetConnection()
        {
            // return new MySqlConnection("database=sblpro_test;server=192.168.215.201;uid=root;pwd=Admin123!");
            return new MySqlConnection("database=db_tripod_system;server=192.168.0.102;uid=root;pwd=123456;port=33306;");
        }

        public T Run<T>(Func<IDbConnection,T> func)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                return func(conn);
            }
        }

        public TEntity Get(dynamic id)
        {
            return Run(conn => {
                return SqlMapperExtensions.Get<TEntity>(conn, id);
            });
        }

        public List<TEntity> GetAll()
        {
            return Run(conn => {
               return conn.GetAll<TEntity>().AsList();
            });
        }

        public bool Delete(TEntity entity)
        {
            return Run(conn => {
               return conn.Delete(entity);
            });
        }

        public long Insert(TEntity entity)
        {
            return Run(conn => {
               return conn.Insert(entity);
            });
        }

        public bool Update(TEntity entity)
        {
            return Run(conn => {
                return conn.Update(entity);
            });
        }
    }
}