using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Factory;
using Auto_Intelligent_Wms.Core.Services.Services;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 工厂
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FactoryController : ApiControllerBase
    {
        private readonly IFactoryService _ifactoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _ifactoryService = factoryService;
        }

        /// <summary>
        /// 查询工厂信息
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Factory>>> GetListAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            var result = await _ifactoryService.GetListAsync(factoryParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询工厂分页
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Factory>>> GetPaginationAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            var result = await _ifactoryService.GetPaginationAsync(factoryParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询工厂信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Factory>> GetFactoryByIdAsync(long id)
        {
            var result = await _ifactoryService.GetFactoryByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取工厂数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Factory>>> GetFactoryByIdsAsync(string ids)
        {
            var result = await _ifactoryService.GetFactoryByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取工厂数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Factory>>> GetFactoryByCodesAsync(string codes)
        {
            var result = await _ifactoryService.GetFactoryByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查询工厂信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Factory>> GetFactoryByCodeAsync(string code)
        {
            var result = await _ifactoryService.GetFactoryByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断工厂是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _ifactoryService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建工厂
        /// </summary>
        /// <param name="createOrUpdateFactoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateFactoryDTO createOrUpdateFactoryDTO)
        {
            var result = await _ifactoryService.CreateAsync(createOrUpdateFactoryDTO,long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除工厂信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _ifactoryService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _ifactoryService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            return await _ifactoryService.ExportAsync(factoryParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _ifactoryService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
