using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace DAL
{
    //public class DBHelper
    //{
    //   // static SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ShopDB;Integrated Security=True");
    //    public static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["strCon"]);
    //    /// <summary>
    //    /// 增加  删除  修改
    //    /// 一般用于添加数据、删除数据、批量删除数据、修改数据
    //    /// 修改状态、点赞、评论、注册
    //    /// </summary>
    //    /// <param name="sql"></param>
    //    /// <returns></returns>
    //    public static int ExecuteNonQuery(string sql)
    //    {
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand(sql, conn);
    //        int n = cmd.ExecuteNonQuery();
    //        conn.Close();
    //        return n;
    //    }
    //    /// <summary>
    //    /// 显示
    //    /// 一般用于显示、查询、分页、反填 
    //    /// </summary>
    //    /// <param name="sql"></param>
    //    /// <returns></returns>
    //    public static DataTable GetDataTable(string sql)
    //    {
    //        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
    //        DataTable dt = new DataTable();
    //        sda.Fill(dt);
    //        return dt;
    //    }
    //    /// <summary>
    //    /// 返回首行首列
    //    /// 一般用于登录、求总条数
    //    /// </summary>
    //    /// <param name="sql"></param>
    //    /// <returns></returns>
    //    public static object ExecuteScalar(string sql)
    //    {
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand(sql, conn);
    //        object n = cmd.ExecuteScalar();
    //        conn.Close();
    //        return n;

    //    }
    //}
}
