using Auto_Intelligent_Wms.Core.Model.BaseModel;
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
    public class MaterialSupplierRelationShipParamsDTO:BasicQuery
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string? MaterialCode { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string? SupplierCode { get; set; }

    }
}
