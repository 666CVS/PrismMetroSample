using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrismMetroSample.Infrastructure.Models;

namespace PrismMetroSample.Infrastructure.Services.MES
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PermissionService
    {
        /// <summary>
        /// 递归遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerable<dynamic> MenuList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString))
            {
                //拼接SQL语句
                string query = "SELECT Permissions.Id,Permissions.PId,Permissions.PermissionName,Permissions.PermissionUrl from  Permissions ORDER BY Permissions.Id";
                return db.Query<User>(query);
            };

        }
    }
}
