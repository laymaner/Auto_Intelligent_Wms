using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Area;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IAreaService
    {
        /// <summary>
        /// 查询库区信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<Area>> GetListAsync([FromQuery] AreaParamsDTO areaParamsDTO);

        /// <summary>
        /// 查询库区分页
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Area>> GetPaginationAsync([FromQuery] AreaParamsDTO areaParamsDTO);

        /// <summary>
        /// 根据id查询库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Area> GetAreaByIdAsync(long id);

        /// <summary>
        /// 根据code查询库区信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Area> GetAreaByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取库区数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Area>> GetAreaByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取库区数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Area>> GetAreaByCodesAsync(string codes);

        /// <summary>
        /// 判断库区是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建库区
        /// </summary>
        /// <param name="createAreaDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateAreaDTO createAreaDTO, long currentUserId);

        /// <summary>
        /// 根据id删除库区信息
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
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] AreaParamsDTO areaParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
