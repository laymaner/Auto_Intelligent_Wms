using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Supplier;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auto_Intelligent_Wms.Core.WebApi.Controllers
{
    /// <summary>
    /// 供应商
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ApiControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        /// <summary>
        /// 查询供应商信息
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Supplier>>> GetListAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            var result = await _supplierService.GetListAsync(supplierParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询供应商分页
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Supplier>>> GetPaginationAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            var result = await _supplierService.GetPaginationAsync(supplierParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Supplier>> GetSupplierByIdAsync(long id)
        {
            var result = await _supplierService.GetSupplierByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取供应商数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Supplier>>> GetSupplierByIdsAsync(string ids)
        {
            var result = await _supplierService.GetSupplierByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取供应商数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Supplier>>> GetSupplierByCodesAsync(string codes)
        {
            var result = await _supplierService.GetSupplierByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查供应商信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Supplier>> GetSupplierByCodeAsync(string code)
        {
            var result = await _supplierService.GetSupplierByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断供应商是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _supplierService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建供应商
        /// </summary>
        /// <param name="createSupplierDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateSupplierDTO createSupplierDTO)
        {
            var result = await _supplierService.CreateAsync(createSupplierDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _supplierService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _supplierService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            return await _supplierService.ExportAsync(supplierParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _supplierService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
