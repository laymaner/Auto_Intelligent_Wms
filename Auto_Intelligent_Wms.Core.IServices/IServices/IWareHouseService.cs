using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IWareHouseService
    {
        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<WareHouse>> GetListAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO);

        /// <summary>
        /// 查询仓库分页
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<WareHouse>> GetPaginationAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO);

        /// <summary>
        /// 根据id查询仓库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<WareHouse> GetWareHouseByIdAsync(long id);

        /// <summary>
        /// 根据code查询仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<WareHouse> GetWareHouseByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取仓库数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<WareHouse>> GetWareHouseByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取仓库数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<WareHouse>> GetWareHouseByCodesAsync(string codes);

        /// <summary>
        /// 判断仓库是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建仓库
        /// </summary>
        /// <param name="createWareHouseDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateWareHouseDTO createWareHouseDTO, long currentUserId);

        /// <summary>
        /// 根据id删除仓库信息
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
        public Task<ActionResult<string>> ExportAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
