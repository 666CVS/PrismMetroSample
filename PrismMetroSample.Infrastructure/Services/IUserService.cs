using Max.PH6_2006A.LowCode.IRespository;
using PrismMetroSample.Infrastructure.Interceptor.HandlerAttributes;
using PrismMetroSample.Infrastructure.Models;
using System.Collections.Generic;

namespace PrismMetroSample.Infrastructure.Services
{
    [LogHandler]
   public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
    }

}
