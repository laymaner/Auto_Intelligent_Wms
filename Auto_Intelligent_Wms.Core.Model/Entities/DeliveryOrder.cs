namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 出库单
    /// </summary>
    public class DeliveryOrder
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 出库单编号
        /// </summary>
        public string DeliveryOrderCode { get; set; }

        /// <summary>
        /// 出库单类型
        /// </summary>
        public string DeliveryOrderType { get; set; }

        /// <summary>
        /// 出库单类型描述
        /// </summary>
        public string? DeliveryOrderTypeDesc { get; set; }

        /// <summary>
        /// 出库所选的工厂
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// 出库所选的仓库
        /// </summary>
        public string WareHouseCode { get; set; }


        /// <summary>
        /// 出库当前步骤 1:待出库 2:已出库
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime? DeliveryTime { get; set; }

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
