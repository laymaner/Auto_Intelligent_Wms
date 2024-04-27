using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 存放精确位置
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 存放精确位置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 存放精确位置编码 01010101  ----第一巷道 第一排 第一列 第一层 第一格
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 货位id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 巷道
        /// </summary>
        public int RoadWay { get; set; }

        /// <summary>
        /// 排
        /// </summary>
        public int LRow { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public int LColumn { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// 第几格
        /// </summary>
        public int Lattice { get; set; }

        /// <summary>
        /// 入库锁定标识 0：未锁定 1：已锁定
        /// </summary>
        public int ImpLock { get; set; }

        /// <summary>
        /// 出库锁定标识 0：未锁定 1：已锁定
        /// </summary>
        public int ExpLock { get; set; }

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
