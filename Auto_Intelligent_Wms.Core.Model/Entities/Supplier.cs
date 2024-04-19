namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 供应商地址
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string? Telephone { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string? Email { get; set; }

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
