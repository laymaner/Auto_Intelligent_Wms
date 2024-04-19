using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IShelfService
    {
        /// <summary>
        /// 查询货架信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<Shelf>> GetListAsync([FromQuery] ShelfParamsDTO shelfParamsDTO);

        /// <summary>
        /// 查询货架分页
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Shelf>> GetPaginationAsync([FromQuery] ShelfParamsDTO shelfParamsDTO);

        /// <summary>
        /// 根据id查询货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Shelf> GetShelfByIdAsync(long id);

        /// <summary>
        /// 根据code查询货架信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Shelf> GetShelfByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取货架数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Shelf>> GetShelfByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取货架数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Shelf>> GetShelfByCodesAsync(string codes);

        /// <summary>
        /// 判断货架是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建货架
        /// </summary>
        /// <param name="createOrUpdateFactoryDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateShelfDTO  createOrUpdateFactoryDTO, long currentUserId);

        /// <summary>
        /// 根据id删除货架信息
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
        /// <param name=""></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] ShelfParamsDTO shelfParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
