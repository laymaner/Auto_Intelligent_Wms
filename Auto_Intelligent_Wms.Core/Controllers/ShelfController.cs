using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 货架
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ShelfController : ApiControllerBase
    {
        private readonly IShelfService _ishelfService;

        public ShelfController(IShelfService shelfService)
        {
            _ishelfService = shelfService;
        }

        /// <summary>
        /// 查询货架信息
        /// </summary>
        /// <param name="shelfParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Shelf>>> GetListAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            var result = await _ishelfService.GetListAsync(shelfParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询货架分页
        /// </summary>
        /// <param name="shelfParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Shelf>>> GetPaginationAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            var result = await _ishelfService.GetPaginationAsync(shelfParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Shelf>> GetShelfByIdAsync(long id)
        {
            var result = await _ishelfService.GetShelfByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取货架数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Shelf>>> GetShelfByIdsAsync(string ids)
        {
            var result = await _ishelfService.GetShelfByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取库位数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Shelf>>> GetShelfByCodesAsync(string codes)
        {
            var result = await _ishelfService.GetShelfByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查库位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Shelf>> GetShelfByCodeAsync(string code)
        {
            var result = await _ishelfService.GetShelfByCodeAsync(code);
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
            var result = await _ishelfService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建库位
        /// </summary>
        /// <param name="createShelfDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateShelfDTO createShelfDTO)
        {
            var result = await _ishelfService.CreateAsync(createShelfDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
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
            var result = await _ishelfService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _ishelfService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="shelfParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            return await _ishelfService.ExportAsync(shelfParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _ishelfService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
