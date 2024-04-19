namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 货架
    /// </summary>
    public class Shelf
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 货架名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 库位id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        public string LocationCode { get; set; }

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
