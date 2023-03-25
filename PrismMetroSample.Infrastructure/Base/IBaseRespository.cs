using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.PH6_2006A.LowCode.IRespository
{
    public interface IBaseRespository<T> where T : class,new()
    {
        //T 的位置：SystemUser
        #region 同步方法
        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="buffered">是否将数据放入内存[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回单个对象</returns>
        T QueryFirst(string sql,
                                        object? param = null,
                                        IDbTransaction? transcation = null,
                                        int? commandTimeut = null,
                                        CommandType? commandType = null);

        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="buffered">是否将数据放入内存[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回结果集</returns>
        IEnumerable<T> Query(string sql,
                                        object? param = null,
                                        IDbTransaction? transcation = null,
                                        bool buffered = true,
                                        int? commandTimeut = null,
                                        CommandType? commandType = null);

        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回受影响行数</returns>
        int Execute(string sql,
                    object? param = null,
                    IDbTransaction? transcation = null,
                    int? commandTimeut = null,
                    CommandType? commandType = null);


        #endregion

        #region 异步方法
        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回单个对象</returns>
        Task<T> QueryFirstAsync(string sql,
                                        object? param = null,
                                        IDbTransaction? transcation = null,
                                        int? commandTimeut = null,
                                        CommandType? commandType = null);

        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回结果集</returns>
        Task<IEnumerable<T>> QueryAsync(string sql,
                                        object? param = null,
                                        IDbTransaction? transcation = null,
                                        int? commandTimeut = null,
                                        CommandType? commandType = null);


        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="transcation">事务[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回动态结果集</returns>
        Task<IEnumerable<dynamic>> QueryDynamicAsync(string sql,
                                        object? param = null,
                                        IDbTransaction? transcation = null,
                                        int? commandTimeut = null,
                                        CommandType? commandType = null);

        /// <summary>
        /// 执行查询sql语句或存储过程，
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数[可选]</param>
        /// <param name="startTran">是否开户事务，默认false[可选]</param>
        /// <param name="commandTimeut">超时[可选]</param>
        /// <param name="commandType">sql语句类型（是sql语句还是存储过程）[可选]</param>
        /// <returns>返回受影响行数</returns>
        Task<int> ExecuteAsync(string sql,
                    object? param = null,
                    bool startTran = false,
                    int? commandTimeut = null,
                    CommandType? commandType = null);

        /*
         * 执行多条非查询多表的Sql语句(开启事务）
         * Date：2023/2/10
         * **/
        /// <summary>
        /// 执行多条Sql语句(默认开启事务）
        /// </summary>
        /// <param name="sqls"></param>
        /// <param name="isTranscation"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlMuitple(Dictionary<string, object> sqls, bool isTranscation = true);

        #endregion
    }
}
