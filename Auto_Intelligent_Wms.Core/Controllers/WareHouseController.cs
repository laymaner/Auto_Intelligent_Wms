using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 仓库
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class WareHouseController : ApiControllerBase
    {
        private readonly IWareHouseService _iwareHouseService;

        public WareHouseController(IWareHouseService wareHouseService)
        {
            _iwareHouseService = wareHouseService;
        }

        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<WareHouse>>> GetListAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            var result = await _iwareHouseService.GetListAsync(wareHouseParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询仓库分页
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<WareHouse>>> GetPaginationAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            var result = await _iwareHouseService.GetPaginationAsync(wareHouseParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询仓库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<WareHouse>> GetWareHouseByIdAsync(long id)
        {
            var result = await _iwareHouseService.GetWareHouseByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取仓库数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<WareHouse>>> GetWareHouseByIdsAsync(string ids)
        {
            var result = await _iwareHouseService.GetWareHouseByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取仓库数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<WareHouse>>> GetWareHouseByCodesAsync(string codes)
        {
            var result = await _iwareHouseService.GetWareHouseByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<WareHouse>> GetWareHouseByCodeAsync(string code)
        {
            var result = await _iwareHouseService.GetWareHouseByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断仓库是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _iwareHouseService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建仓库
        /// </summary>
        /// <param name="createWareHouseDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateWareHouseDTO createWareHouseDTO)
        {
            var result = await _iwareHouseService.CreateAsync(createWareHouseDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除仓库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _iwareHouseService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
       
        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _iwareHouseService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            return await _iwareHouseService.ExportAsync(wareHouseParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _iwareHouseService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
