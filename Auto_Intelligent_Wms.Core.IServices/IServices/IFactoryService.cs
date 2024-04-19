using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IFactoryService
    {
        /// <summary>
        /// 查询工厂信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<Factory>> GetListAsync([FromQuery] FactoryParamsDTO factoryParamsDTO);

        /// <summary>
        /// 查询工厂分页
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Factory>> GetPaginationAsync([FromQuery] FactoryParamsDTO factoryParamsDTO);

        /// <summary>
        /// 根据id查询工厂信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Factory> GetFactoryByIdAsync(long id);

        /// <summary>
        /// 根据ids集合获取工厂数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Factory>> GetFactoryByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取工厂数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Factory>> GetFactoryByCodesAsync(string codes);

        /// <summary>
        /// 根据code查询工厂信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Factory> GetFactoryByCodeAsync(string code);

        /// <summary>
        /// 判断工厂是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建工厂
        /// </summary>
        /// <param name="createOrUpdateFactoryDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateFactoryDTO createOrUpdateFactoryDTO,long currentUserId);

        /// <summary>
        /// 根据id删除工厂信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<long> DelAsync(long id,long currentUserId);

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
        public Task<ActionResult<string>> ExportAsync([FromQuery] FactoryParamsDTO factoryParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);


    }
}
