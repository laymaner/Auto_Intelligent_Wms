using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auto_Intelligent_Wms.Core.WebApi.Controllers
{
    /// <summary>
    /// 物料
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MaterialController : ApiControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService) 
        {
            _materialService = materialService;
        }

        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Material>>> GetListAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            var result = await _materialService.GetListAsync(materialParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询物料分页
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Material>>> GetPaginationAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            var result = await _materialService.GetPaginationAsync(materialParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id查询物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Material>> GetMaterialByIdAsync(long id)
        {
            var result = await _materialService.GetMaterialByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取物料数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Material>>> GetMaterialByIdsAsync(string ids)
        {
            var result = await _materialService.GetMaterialByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取物料数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Material>>> GetMaterialByCodesAsync(string codes)
        {
            var result = await _materialService.GetMaterialByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据code查物料信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Material>> GetMaterialByCodeAsync(string code)
        {
            var result = await _materialService.GetMaterialByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断物料是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _materialService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建物料
        /// </summary>
        /// <param name="createMaterialDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync([FromBody] CreateMaterialDTO createMaterialDTO)
        {
            var result = await _materialService.CreateAsync(createMaterialDTO, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id删除物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var result = await _materialService.DelAsync(id, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _materialService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            return await _materialService.ExportAsync(materialParamsDTO);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var result = await _materialService.ImportAsync(path, long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value));
            return SuccessResult(result);
        }
    }
}
