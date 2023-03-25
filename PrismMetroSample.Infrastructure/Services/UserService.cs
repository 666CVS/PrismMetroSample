using Dapper;
using Max.PH6_2006A.LowCode.DataAccess;
using Max.PH6_2006A.LowCode.IRespository;
using Max.PH6_2006A.LowCode.Respository;
using PrismMetroSample.Infrastructure.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrismMetroSample.Infrastructure.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString))
            {
                string query = "SELECT Id,LoginId,PassWord from users order by Id";
                return db.Query<User>(query);
            }
        }
    }
}