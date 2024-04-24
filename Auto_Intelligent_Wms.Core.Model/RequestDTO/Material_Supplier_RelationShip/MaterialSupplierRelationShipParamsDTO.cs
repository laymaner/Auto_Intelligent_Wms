using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Material_Supplier_RelationShip
{
    /// <summary>
    /// 供应商物料查询实体参数
    /// </summary>
    public class MaterialSupplierRelationShipParamsDTO
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string? MaterialCode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string? MaterialName { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string? MaterialType { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string? SupplierCode { get; set; }

        /// <summary>
        /// 供应商姓名
        /// </summary>
        public string? SupplierName { get; set; }
    }
}
