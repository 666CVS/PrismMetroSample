using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Core;

namespace PrismMetroSample.Infrastructure.Models
{
    /// <summary>
    /// 领料单生成表
    /// </summary>
    public class materialRequisition
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }=new IdWorker(1,0).ToString();
        /// <summary>
        /// 作业编号
        /// </summary>
        public string jopNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
