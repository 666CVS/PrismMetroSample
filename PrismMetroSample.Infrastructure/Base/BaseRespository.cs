using Dapper;
using Max.PH6_2006A.LowCode.DataAccess;
using Max.PH6_2006A.LowCode.IRespository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Max.PH6_2006A.LowCode.Respository
{
    public class BaseRespository<T> : IBaseRespository<T> where T : class, new()
    {
        DapperHelper _dapper;
        public BaseRespository(DapperHelper dapper)
        {
            _dapper = dapper;
        }

        //执行sql
        public int Execute(string sql, object? param = null, IDbTransaction? transcation = null, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                int result = conn.Execute(sql, param, transcation, commandTimeut, commandType);
                return result;
            }
        }

        //执行sql（异步）
        public async Task<int> ExecuteAsync(string sql, object? param = null, bool startTran = false, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                int result = 0;
                if (startTran)
                {
                    //TranscationScope
                    IDbTransaction transcation = conn.BeginTransaction();
                    try
                    {
                        result = await conn.ExecuteAsync(sql, param, transcation, commandTimeut, commandType);
                        transcation.Commit();
                    }
                    catch (Exception)
                    {
                        transcation.Rollback();
                        throw;
                    }
                }
                else
                {
                    result = await conn.ExecuteAsync(sql, param, null, commandTimeout: commandTimeut, commandType);
                }

                return result;
            }
        }

        //查询sql
        public IEnumerable<T> Query(string sql, object? param = null, IDbTransaction? transcation = null, bool buffered = true, int? commandTimeut = null, CommandType? commandType = null)
        {
            //DynamicParameters Dapper参数化
            using (IDbConnection conn = _dapper.DbConnection)
            {
                IEnumerable<T> result = conn.Query<T>(sql, param, transcation, buffered, commandTimeut, commandType);
                return result;
            }
        }


        //查询sql（异步）
        public async Task<IEnumerable<T>> QueryAsync(string sql, object? param = null, IDbTransaction? transcation = null, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                var result = await conn.QueryAsync<T>(sql, param, transcation, commandTimeut, commandType);
                return result;
            }
        }

        public async Task<IEnumerable<dynamic>> QueryDynamicAsync(string sql, object? param = null, IDbTransaction? transcation = null, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                var result = await conn.QueryAsync<dynamic>(sql, param, transcation, commandTimeut, commandType);
                return result;
            }
        }


        //查询一条数据sql
        public T QueryFirst(string sql, object? param = null, IDbTransaction? transcation = null, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                var result = conn.QueryFirst<T>(sql, param, transcation, commandTimeut, commandType);
                return result;
            }
        }

        //查询一条数据sql（异步）
        public async Task<T> QueryFirstAsync(string sql, object? param = null, IDbTransaction? transcation = null, int? commandTimeut = null, CommandType? commandType = null)
        {
            using (IDbConnection conn = _dapper.DbConnection)
            {
                var result = await conn.QueryFirstAsync<T>(sql, param, transcation, commandTimeut, commandType);
                return result;
            }
        }

        /// <summary>
        /// 执行多条Sql语句(对不同表也可以操作的。默认带事务）
        /// </summary>
        /// <param name="sqls"></param>
        /// <param name="isTranscation"></param>
        /// <returns></returns>
        public async Task<int> ExecuteSqlMuitple(Dictionary<string, object> sqls, bool isTranscation = true)
        {
            int result = 0;
            using (IDbConnection conn = _dapper.DbConnection)
            {
                conn.Open();
                if (isTranscation)
                {
                    IDbTransaction transcation = conn.BeginTransaction();
                    try
                    {
                        foreach (KeyValuePair<string, object> item in sqls)
                        {
                            string sql = item.Key;
                            object param = item.Value;
                            result += await conn.ExecuteAsync(sql, param, transcation);
                        }
                        transcation.Commit();
                    }
                    catch (Exception)
                    {
                        transcation.Rollback();
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        foreach (KeyValuePair<string, object> item in sqls)
                        {
                            string sql = item.Key;
                            object param = item.Value;
                            result += await conn.ExecuteAsync(sql, param);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return result;
            }
        }
    }
}
