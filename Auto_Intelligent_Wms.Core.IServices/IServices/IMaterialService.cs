using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IMaterialService
    {
        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        public Task<List<Material>> GetListAsync([FromQuery] MaterialParamsDTO materialParamsDTO);

        /// <summary>
        /// 查询物料信息分页
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<Material>> GetPaginationAsync([FromQuery] MaterialParamsDTO materialParamsDTO);

        /// <summary>
        /// 根据id查询物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Material> GetMaterialByIdAsync(long id);

        /// <summary>
        /// 根据code查询物料信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Material> GetMaterialByCodeAsync(string code);

        /// <summary>
        /// 根据ids集合获取物料信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Material>> GetMaterialByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取物料信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Material>> GetMaterialByCodesAsync(string codes);

        /// <summary>
        /// 判断物料信息是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 创建物料信息
        /// </summary>
        /// <param name="createMaterialDTO"></param>
        /// <returns></returns>
        public Task<long> CreateAsync([FromBody] CreateMaterialDTO createMaterialDTO, long currentUserId);

        /// <summary>
        /// 根据id删除物料信息
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
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] MaterialParamsDTO materialParamsDTO);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);
    }
}
