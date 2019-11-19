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
    /// <summary>
    /// 数据访问对象基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class BaseDAO<TEntity> where TEntity : class
    {
        /// <summary>
        /// Ctor
        /// </summary>
        static BaseDAO()
        {
            // Dapper 中数据库数据到实体映射时忽视下划线，如列名user_id可以被映射到属性名UserId上
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            // Tripod.Framework.DapperExtentions 中实体模型映射到数据库列名的控制，UserId -> user_id
            SqlMapperExtensions.ColumnNameMapper = (prop) =>
            {
                Regex regex = new Regex("[A-Z]");
                var newSource = regex.Replace(prop.Name, (match) =>
                {
                    return "_" + match.Value.ToLower();
                });
                return newSource.TrimStart('_');
            };
        }

        private readonly string _connectionString;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connectionString">数据库链接字符串</param>
        public BaseDAO(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <returns></returns>
        private IDbConnection GetConnection()
        {
            return new MySqlConnection(this._connectionString);
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Run<T>(Func<IDbConnection, T> func)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                return func(conn);
            }
        }

        /// <summary>
        /// 根据Id获取单个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(dynamic id)
        {
            return Run(conn =>
            {
                return SqlMapperExtensions.Get<TEntity>(conn, id);
            });
        }

        /// <summary>
        /// 获取所有实体对象
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            return Run(conn =>
            {
                return conn.GetAll<TEntity>().AsList();
            });
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            return Run(conn =>
            {
                return conn.Delete(entity);
            });
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(TEntity entity)
        {
            return Run(conn =>
            {
                return conn.Insert(entity);
            });
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            return Run(conn =>
            {
                return conn.Update(entity);
            });
        }

        // 分页
        public PagedList<TEntity> GetPaging(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var tableName = SqlMapperExtensions.GetTableName(typeof(TEntity));
            return GetPaging<TEntity>(innerQuery: tableName, pageIndex: pageIndex, pageSize: pageSize);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="innerQuery">分页前的内部子查询</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="conditions">条件子句(不用包含WHERE,如："AND status = 1 ...")</param>
        /// <param name="projection">外层SELECT子句</param>
        /// <param name="param">查询参数对象</param>
        /// <typeparam name="T">结果集类型</typeparam>
        /// <returns></returns>
        public PagedList<T> GetPaging<T>(string innerQuery, int pageIndex = 1, int pageSize = int.MaxValue, string conditions = "", string projection = "*", object param = null)
            where T : class
        {
            if (string.IsNullOrEmpty(innerQuery))
            {
                throw new ArgumentNullException(nameof(innerQuery));
            }

            StringBuilder builder = new StringBuilder();
            builder.Append($"SELECT COUNT(1) as totalCount FROM ({innerQuery}) as temp WHERE 1 = 1 {conditions};");

            int start = (pageIndex - 1) * pageSize;
            int end = pageIndex * pageSize;
            builder.Append($"SELECT {projection} FROM ({innerQuery}) as temp WHERE 1 = 1 {conditions} LIMIT {start},{end};");

            return Run(conn =>
            {
                string sql = builder.ToString();
                using (var multi = conn.QueryMultiple(sql, param))
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