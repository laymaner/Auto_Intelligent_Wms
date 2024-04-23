using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 货物装载容器
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
        /// 存储货位id
        /// </summary>
        public long? LocationId { get; set; }

        /// <summary>
        /// 存储货位名称
        /// </summary>
        public string? LocationName { get; set; }

        /// <summary>
        /// 存储货位编码
        /// </summary>
        public string? LocationCode { get; set; }

        /// <summary>
        /// 存储状态 不在货位/在货位/任务中
        /// </summary>
        public int? StorageStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否有货 Y/N
        /// </summary>
        public string? HasGoods { get; set; }

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
