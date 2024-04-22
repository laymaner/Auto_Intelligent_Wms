namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 物料
    /// </summary>
    public class Material
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 基本计量单位数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 最小包装数量
        /// </summary>
        public decimal MinimumPackagingQuantity { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

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
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 物料等级
        /// </summary>
        public string? Version { get; set; }

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
