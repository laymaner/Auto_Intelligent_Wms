namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 入库单
    /// </summary>
    public class ReceiptOrder
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库单编号
        /// </summary>
        public string ReceiptOrderCode { get; set; }

        /// <summary>
        /// 入库单类型
        /// </summary>
        public string ReceiptOrderType { get; set; }

        /// <summary>
        /// 入库单类型描述
        /// </summary>
        public string? ReceiptOrderTypeDesc { get; set; }

        /// <summary>
        /// 入库所选的工厂
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// 入库所选的仓库
        /// </summary>
        public string WareHouseCode { get; set; }


        /// <summary>
        /// 入库当前步骤 1:待入库 2:已入库
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? ReceiptTime { get; set; }

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
