using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "货架名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        [Required(ErrorMessage = "货架编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        [Required(ErrorMessage = "库区编码不能为空")]
        public string AreaCode { get; set; }

        /// <summary>
        /// 巷道数量
        /// </summary>
        [Required(ErrorMessage = "巷道数量不能为空")]
        [Range(1, 100, ErrorMessage = "巷道数量介于1~100之间")]
        public int RoadWay { get; set; }

        /// <summary>
        /// 排数
        /// </summary>
        [Required(ErrorMessage = "排数不能为空")]
        [Range(1, 100, ErrorMessage = "排数介于1~100之间")]
        public int ShelfRows { get; set; }

        /// <summary>
        /// 列数
        /// </summary>
        [Required(ErrorMessage = "列数不能为空")]
        [Range(1, 100, ErrorMessage = "列数于1~100之间")]
        public int ShelfColumns { get; set; }

        /// <summary>
        /// 层数
        /// </summary>
        [Required(ErrorMessage = "层数不能为空")]
        [Range(1, 100, ErrorMessage = "层数介于1~100之间")]
        public int ShelfLayers { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
