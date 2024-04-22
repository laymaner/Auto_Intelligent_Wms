using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Location;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface ILocationService
    {
        /// <summary>
        /// 查询货位信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<Location>> GetListAsync([FromQuery] LocationParamsDTO locationParamsDTO);

        /// <summary>
        /// 查询货位分页
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Location>> GetPaginationAsync([FromQuery] LocationParamsDTO locationParamsDTO);

        /// <summary>
        /// 根据id查询货位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Location> GetLocationByIdAsync(long id);

        /// <summary>
        /// 根据code查询货位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Location> GetLocationByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取货位数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Location>> GetLocationByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取货位数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Location>> GetLocationByCodesAsync(string codes);

        /// <summary>
        /// 判断货位是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建库区
        /// </summary>
        /// <param name="createLocationDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateLocationDTO createLocationDTO, long currentUserId);

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
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] LocationParamsDTO locationParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
