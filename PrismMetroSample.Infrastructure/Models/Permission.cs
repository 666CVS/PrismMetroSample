using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.MES.Frame.Models;

namespace PrismMetroSample.Infrastructure.Models
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission
    {
        //主键
        public int Id { get; set; }
        //父级Id
        public int PId { get; set; }
        [StringLength(50)]
        public string PermissionName { get; set; }
        [StringLength(200)]
        public string PermissionUrl{ get; set; }
        public ICommand OpenViewCommand { get; set; }
        public List<Permission> Children { get; set; } = new List<Permission>();
    }
}
