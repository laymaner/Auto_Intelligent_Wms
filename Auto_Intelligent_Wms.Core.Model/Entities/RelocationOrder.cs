namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 移库单
    /// </summary>
    public class RelocationOrder
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 移库单编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 移库类型 1：库内移库 2：库间移库 3：工厂间调拨
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 移库前原----工厂id
        /// </summary>
        public long OriginalFactoryId { get; set; }

        /// <summary>
        /// 移库前原----工厂名称
        /// </summary>
        public string OriginalFactoryName { get; set; }

        /// <summary>
        /// 移库前原----工厂编码
        /// </summary>
        public string OriginalFactoryCode { get; set; }

        /// <summary>
        /// 移库前原----仓库id
        /// </summary>
        public long OriginalWareHouseId { get; set; }

        /// <summary>
        /// 移库前原----仓库名称
        /// </summary>
        public string OriginalWareHouseName { get; set; }

        /// <summary>
        /// 移库前原----仓库编码
        /// </summary>
        public string OriginalWareHouseCode { get; set; }

        /// <summary>
        /// 移库前原----库区id
        /// </summary>
        public long OriginalAreaId { get; set; }

        /// <summary>
        /// 移库前原----库区名称
        /// </summary>
        public string OriginalAreaName { get; set; }

        /// <summary>
        /// 移库前原----库区编码
        /// </summary>
        public string OriginalAreaCode { get; set; }

        /// <summary>
        /// 移库前原----库位id
        /// </summary>
        public long OriginalLocationId { get; set; }

        /// <summary>
        /// 移库前原----库位名称
        /// </summary>
        public string OriginalLocationName { get; set; }

        /// <summary>
        /// 移库前原----库位编码
        /// </summary>
        public string OriginalLocationCode { get; set; }

        /// <summary>
        /// 移库后----工厂id
        /// </summary>
        public long FactoryId { get; set; }

        /// <summary>
        /// 移库后----工厂名称
        /// </summary>
        public string FactoryName { get; set; }

        /// <summary>
        /// 移库后----工厂编码
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// 移库后----仓库id
        /// </summary>
        public long WareHouseId { get; set; }

        /// <summary>
        /// 移库后----仓库名称
        /// </summary>
        public string WareHouseName { get; set; }

        /// <summary>
        /// 移库后----仓库编码
        /// </summary>
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 移库后----库区id
        /// </summary>
        public long AreaId { get; set; }

        /// <summary>
        /// 移库后----库区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 移库后----库区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 移库后----库位id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// 移库后----库位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 移库后----库位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 移库时间
        /// </summary>
        public DateTime? RelocationTime { get; set; }

        /// <summary>
        /// 移库当前步骤：1：待移库 2：已移库
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// 库存ids
        /// </summary>
        public string MaterialStockIds { get; set; }

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
