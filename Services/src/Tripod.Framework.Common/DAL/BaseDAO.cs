using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using Tripod.Framework.DapperExtentions;

namespace Tripod.Framework.Common.DAL
{
    public class BaseDAO<TEntity> where TEntity : class
    {
        static BaseDAO()
        {
            // Dapper 中数据库数据到实体映射时忽视下划线，如列名user_id可以被映射到属性名UserId上
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            // Tripod.Framework.DapperExtentions 中实体模型映射到数据库列名的控制，UserId -> user_id
            SqlMapperExtensions.ColumnNameMapper = (prop) => {
                Regex regex = new Regex("[A-Z]");
                var newSource = regex.Replace(prop.Name, (match) => {
                    return "_" + match.Value.ToLower();
                });
                return newSource.TrimStart('_');
            };
        }

        private readonly string _connectionString;
        public BaseDAO(string connectionString)
        {
            this._connectionString = connectionString;
        }

        private IDbConnection GetConnection()
        {
            return new MySqlConnection(this._connectionString);
            // "database=sblpro_test;server=192.168.215.201;uid=root;pwd=Admin123!"
            // return new MySqlConnection("database=db_tripod_system;server=192.168.0.102;uid=root;pwd=123456;port=33306;");
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

        public PagedList<T> GetPaging<T>(string innerQuery, int pageIndex = 1, int pageSize = int.MaxValue, string conditions = "", string projection = "*", object param = null)
            where T : class
        {
            if(string.IsNullOrEmpty(innerQuery))
            {
                throw new ArgumentNullException(nameof(innerQuery));
            }

            StringBuilder builder = new StringBuilder();
            builder.Append($"SELECT COUNT(1) as totalCount FROM ({innerQuery}) as temp WHERE 1 = 1 {conditions};");

            int start = (pageIndex - 1) * pageSize;
            int end = pageIndex * pageSize;
            builder.Append($"SELECT {projection} FROM ({innerQuery}) as temp WHERE 1 = 1 {conditions} LIMIT {start},{end};");

            return Run(conn => {
                string sql = builder.ToString();
                using(var multi = conn.QueryMultiple(sql, param))
                {
                    int totalCount = multi.Read<int>().Single();
                    var list = multi.Read<T>().ToList();
                    
                    return new PagedList<T>()
                    {
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        TotalCount = totalCount,
                        List = list
                    };
                }
            });
        }
    }
}