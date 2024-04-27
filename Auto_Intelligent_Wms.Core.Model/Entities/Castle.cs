using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 货物装载容器记录
    /// </summary>
    public class Castle
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型 ：1、料箱
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 所属单位
        /// </summary>
        public string? AffiliatedUnit { get; set; }

        /// <summary>
        /// 清洗前原编码集合 例如 A001,A002,A003 后续叠加 逗号分割
        /// </summary>
        public string OriginalCode { get; set; }

        /// <summary>
        /// 清洗次数
        /// </summary>
        public int CleanCount { get; set; }

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
