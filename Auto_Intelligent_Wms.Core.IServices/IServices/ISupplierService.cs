using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Supplier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface ISupplierService
    {
        /// <summary>
        /// 查询供应商信息
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public Task<List<Supplier>> GetListAsync([FromQuery] SupplierParamsDTO supplierParamsDTO);

        /// <summary>
        /// 查询供应商信息分页
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Supplier>> GetPaginationAsync([FromQuery] SupplierParamsDTO supplierParamsDTO);

        /// <summary>
        /// 根据id查询供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Supplier> GetSupplierByIdAsync(long id);

        /// <summary>
        /// 根据code查询供应商信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Supplier> GetSupplierByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取供应商信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Supplier>> GetSupplierByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取供应商信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Supplier>> GetSupplierByCodesAsync(string codes);

        /// <summary>
        /// 判断供应商信息是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建供应商信息
        /// </summary>
        /// <param name="createSupplierDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateSupplierDTO createSupplierDTO, long currentUserId);

        /// <summary>
        /// 根据id删除供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<long> DelAsync(long id, long currentUserId);

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult<string>> DownloadTemplateAsync();

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] SupplierParamsDTO supplierParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
