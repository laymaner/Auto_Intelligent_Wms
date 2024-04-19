using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Location;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 库位
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LocationController : ApiControllerBase
    {
        private readonly ILocationService _ilocationService;

        public LocationController(ILocationService locationService)
        {
            _ilocationService = locationService;
        }

        /// <summary>
        /// 查询库位信息
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Location>>> GetListAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            var result = await _ilocationService.GetListAsync(locationParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询库位分页
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Location>>> GetPaginationAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            var result = await _ilocationService.GetPaginationAsync(locationParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询库位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Location>> GetLocationByIdAsync(long id)
        {
            var result = await _ilocationService.GetLocationByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取库位数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Location>>> GetLocationByIdsAsync(string ids)
        {
            var result = await _ilocationService.GetLocationByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取库位数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Location>>> GetLocationByCodesAsync(string codes)
        {
            var result = await _ilocationService.GetLocationByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查库位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Location>> GetLocationByCodeAsync(string code)
        {
            var result = await _ilocationService.GetLocationByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断库位是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _ilocationService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建库位
        /// </summary>
        /// <param name="createLocationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateLocationDTO createLocationDTO)
        {
            var result = await _ilocationService.CreateAsync(createLocationDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除库位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _ilocationService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _ilocationService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            return await _ilocationService.ExportAsync(locationParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _ilocationService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
