using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf
{
    /// <summary>
    /// 创建货架实体参数
    /// </summary>
    public class CreateShelfDTO
    {
        /// <summary>
        /// 货架名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 巷道数量
        /// </summary>
        public int RoadWay { get; set; }

        /// <summary>
        /// 排数
        /// </summary>
        public int ShelfRows { get; set; }

        /// <summary>
        /// 列数
        /// </summary>
        public int ShelfColumns { get; set; }

        /// <summary>
        /// 层数
        /// </summary>
        public int ShelfLayers { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
