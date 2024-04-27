using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 出库单明细
    /// </summary>
    public class ExpOrder_Items
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 出库单id
        /// </summary>
        public long ExpOrderId { get; set; }

        /// <summary>
        /// Castle编码
        /// </summary>
        public string CastleCode { get; set; }

        /// <summary>
        /// Castle类型
        /// </summary>
        public string CastleType { get; set; }

        /// <summary>
        /// 仓储库区位置
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 仓储货架位置
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 仓储货位位置
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 存放精确位置编码
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// SnCode
        /// </summary>
        public string SnCode { get; set; }

        /// <summary>
        /// 出库口编码
        /// </summary>
        public string PassageWayCode { get; set; }

        /// <summary>
        /// 计划出库货物数量
        /// </summary>
        public decimal PlanExpQuantity { get; set; }

        /// <summary>
        /// 实际出库货物数量
        /// </summary>
        public decimal ActualExpQuantity { get; set; }

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
