using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "货位名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 货位编码
        /// </summary>
        [Required(ErrorMessage = "货位编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        [Required(ErrorMessage = "货架编码不能为空")]
        public string ShelfCode { get; set; }

        /// <summary>
        /// 巷道
        /// </summary>
        [Required(ErrorMessage = "巷道不能为空")]
        [Range(1, 100, ErrorMessage = "巷道介于1~100之间")]
        public int RoadWay { get; set; }

        /// <summary>
        /// 排
        /// </summary>
        [Required(ErrorMessage = "排不能为空")]
        [Range(1, 100, ErrorMessage = "排介于1~100之间")]
        public int LRow { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [Required(ErrorMessage = "列不能为空")]
        [Range(1, 100, ErrorMessage = "列介于1~100之间")]
        public int LColumn { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        [Required(ErrorMessage = "层不能为空")]
        [Range(1, 100, ErrorMessage = "层介于1~100之间")]
        public int Layer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
