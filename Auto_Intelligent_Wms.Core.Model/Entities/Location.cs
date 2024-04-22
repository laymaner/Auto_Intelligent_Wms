   namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 货位
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 货架id
        /// </summary>
        public long ShelfId { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 货架名称
        /// </summary>
        public string ShelfName { get; set; }

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
