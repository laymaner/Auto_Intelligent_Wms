using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    /// <summary>
    /// 通道
    /// </summary>
    public class PassageWay
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 通道类型 1：入库口 2：出库口
        /// </summary>
        public int Type { get; set; }

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
        /// 一号巷道
        /// </summary>
        public string? FirstLanway { get; set; }

        /// <summary>
        /// 二号巷道
        /// </summary>
        public string? SecondLanway { get; set; }

        /// <summary>
        /// 三号巷道
        /// </summary>
        public string? ThirdtLanway { get; set; }

        /// <summary>
        /// 四号巷道
        /// </summary>
        public string? ForthLanway { get; set; }

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
