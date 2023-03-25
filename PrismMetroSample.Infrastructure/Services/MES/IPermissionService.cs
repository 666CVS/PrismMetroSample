using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMetroSample.Infrastructure.Services.MES
{
    /// <summary>
    /// 权限
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<dynamic> MenuList();
    }
}
