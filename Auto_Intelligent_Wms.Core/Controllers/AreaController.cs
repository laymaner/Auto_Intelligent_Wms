using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Area;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 库区
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AreaController : ApiControllerBase
    {
        private readonly IAreaService _iareaService;

        public AreaController(IAreaService areaService)
        {
            _iareaService = areaService;
        }

        /// <summary>
        /// 查询库区信息
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Area>>> GetListAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            var result = await _iareaService.GetListAsync(areaParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询库区分页
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Area>>> GetPaginationAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            var result = await _iareaService.GetPaginationAsync(areaParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Area>> GetAreaByIdAsync(long id)
        {
            var result = await _iareaService.GetAreaByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取库区数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Area>>> GetAreaByIdsAsync(string ids)
        {
            var result = await _iareaService.GetAreaByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取库区数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Area>>> GetAreaByCodesAsync(string codes)
        {
            var result = await _iareaService.GetAreaByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查库区信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Area>> GetAreaByCodeAsync(string code)
        {
            var result = await _iareaService.GetAreaByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断库区是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _iareaService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建库区
        /// </summary>
        /// <param name="createAreaDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateAreaDTO createAreaDTO)
        {
            var result = await _iareaService.CreateAsync(createAreaDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _iareaService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _iareaService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            return await _iareaService.ExportAsync(areaParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _iareaService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
