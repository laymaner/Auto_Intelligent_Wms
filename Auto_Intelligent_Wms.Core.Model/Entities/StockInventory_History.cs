using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    public class StockInventory_History
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 关联单号
        /// </summary>
        public string RelatedOrder { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// Castle编码
        /// </summary>
        public string CastleCode { get; set; }

        /// <summary>
        /// Castle类型
        /// </summary>
        public int CastleType { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 物料等级
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 每个/价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        public string PriceUnit { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// 是否锁定 N/Y
        /// </summary>
        public string? IsLock { get; set; }

        /// <summary>
        /// 是否占用 N/Y
        /// </summary>
        public string? IsOccupy { get; set; }

        /// <summary>
        /// 是否报废 N/Y
        /// </summary>
        public string? IsScrap { get; set; }

        /// <summary>
        /// 是否冻结 N/Y
        /// </summary>
        public string? IsFreeze { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 操作库存数量
        /// </summary>
        public decimal OperateQuantity { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperateType { get; set; }

        /// <summary>
        /// 操作类型描述
        /// </summary>
        public string OperateTypeDesc { get; set; }

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
