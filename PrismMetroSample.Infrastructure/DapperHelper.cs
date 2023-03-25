/*
 * Subject：Dapper的基本操作帮助类
 * Date：2023/03/23
 * Author：Max
 * Content：包含Dapper的CRUD的操作
 * Modify：
 *      Date：2023/03/23
 *      Content：添加了一个xxxx方法
 * 
 * **/
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.PH6_2006A.LowCode.DataAccess
{
    /*
     * Dapper是基本IDbConnection
     * 
     * **/
    public class DapperHelper
    {
        public IDbConnection DbConnection { get; }
        public DapperHelper()
        {
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
        }
        public  void Test()
        {
            DbConnection.Open();
            int a =DbConnection.Execute("",null,null,null,CommandType.StoredProcedure);
            IEnumerable<dynamic> data =  DbConnection.Query("", null, null, true, null, null);
        }
    }




}
