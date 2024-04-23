﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 入库单明细
    /// </summary>
    public class ImpOrder_Items
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库单id
        /// </summary>
        public long ImpOrderId { get; set; }

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
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 入库口
        /// </summary>
        public string PassageWayCode { get; set; }

        /// <summary>
        /// 计划入库货物数量
        /// </summary>
        public decimal PlanImpQuantity { get; set; }

        /// <summary>
        /// 实际入库货物数量
        /// </summary>
        public decimal ActualImpQuantity { get; set; }

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