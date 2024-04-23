using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class Operate_Log
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType { get; set; }

        /// <summary>
        /// 操作路径
        /// </summary>
        public string OperateUrl { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string? OperateParams { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        public int OperateStatus { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMsg { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long Creator { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public long? Updator { get; set; }






    }
}
