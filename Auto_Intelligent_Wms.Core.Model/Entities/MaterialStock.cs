namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 库存
    /// </summary>
    public class MaterialStock
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 物料id
        /// </summary>
        public long MaterialId { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string MaterialType { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        public long SupplierId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 工厂id
        /// </summary>
        public long FactoryId { get; set; }

        /// <summary>
        /// 工厂名称
        /// </summary>
        public string FactoryName { get; set; }

        /// <summary>
        /// 工厂编号
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// 仓库id
        /// </summary>
        public long WareHouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WareHouseName { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WareHouseCode { get; set; }

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
        /// 数量
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
        /// 是否锁定
        /// </summary>
        public string IsLock { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        public string IsFreeze { get; set; }

        /// <summary>
        /// 是否占用
        /// </summary>
        public string IsOccupy { get; set; }

        /// <summary>
        /// 是否报废
        /// </summary>
        public string IsScrap { get; set; }

        /// <summary>
        /// 是否合格
        /// </summary>
        public string IsEligibility { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 托标签
        /// </summary>
        public string TrayNo { get; set; }

        /// <summary>
        /// SN标签
        /// </summary>
        public string SnTag { get; set; }

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
