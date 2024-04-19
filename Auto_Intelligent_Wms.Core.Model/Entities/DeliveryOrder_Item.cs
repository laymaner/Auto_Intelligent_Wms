namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 出库单明细
    /// </summary>
    public class DeliveryOrder_Item
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 出库单id
        /// </summary>
        public long DeliveryOrderId { get; set; }

        /// <summary>
        /// 物料id
        /// </summary>
        public long MaterialId { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public long SupplierId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>

        public string SupplierName { get; set; }

        /// <summary>
        /// 库区id
        /// </summary>
        public long AreaId { get; set; }

        /// <summary>
        /// 库区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 库位id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        public string PriceUint { get; set; }

        /// <summary>
        /// 每个/价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// 实际出库数量
        /// </summary>
        public decimal RelDeliveryQuantity { get; set; }

        /// <summary>
        /// 库存id
        /// </summary>
        public long MaterialStockId { get; set; }

        /// <summary>
        /// 出库当前步骤 1:待出库 2:已出库
        /// </summary>
        public int Step { get; set; }


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
