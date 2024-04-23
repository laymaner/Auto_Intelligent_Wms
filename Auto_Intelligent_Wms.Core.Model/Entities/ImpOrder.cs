using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 入库单
    /// </summary>
    public class ImpOrder
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 入库单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? ImpTime { get; set; }

        /// <summary>
        /// 入库步骤
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
