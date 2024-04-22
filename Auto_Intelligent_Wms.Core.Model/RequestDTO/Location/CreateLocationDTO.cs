using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Location
{
    /// <summary>
    /// 创建货位实体参数
    /// </summary>
    public class CreateLocationDTO
    {
        /// <summary>
        /// 货位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string ShelfCode { get; set; }

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
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
