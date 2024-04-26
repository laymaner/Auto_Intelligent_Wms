using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.User;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class UserService :IUserService
    {
        private readonly IOptionsSnapshot<JWTOptions> _jwtOptionsSnapshot;
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<UserService> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserService(ILogger<UserService> logger, IWebHostEnvironment webHostEnvironment, IOptionsSnapshot<JWTOptions> jwtOptionsSnapshot, Auto_Inteligent_Wms_DbContext db)
        {
            _logger = logger;
            _jwtOptionsSnapshot = jwtOptionsSnapshot;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <returns></returns>
        public async Task<long> CreateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO, string currentUserId)
        {
            User user = new User();
            if (!string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Code))
            {
                if (await IsExistAsync(createOrUpdateUserDTO.Code))
                {
                    throw new Exception($"User code {createOrUpdateUserDTO.Code} already exists, duplicate creation is not allowed");
                }
                user.Code = createOrUpdateUserDTO.Code;
            }
            else
            {
                throw new Exception("User code cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Name))
            {
                throw new Exception("User name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Gender))
            {
                throw new Exception("User gender cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Password))
            {
                throw new Exception("User password cannot be empty");
            }
            user.Name = createOrUpdateUserDTO.Name;
            user.Password = MD5EncryptionUtil.Encrypt(createOrUpdateUserDTO.Password);
            user.Gender = createOrUpdateUserDTO.Gender;
            user.Status = (int)DataStatus.Normal;
            user.Age = createOrUpdateUserDTO.Age;
            user.Email = createOrUpdateUserDTO.Email;
            user.Address = createOrUpdateUserDTO.Address;
            user.Birth = createOrUpdateUserDTO.Birth;
            user.Phone = createOrUpdateUserDTO.Phone;
            user.Remark = createOrUpdateUserDTO.Remark;
            user.JWTVersion = 0;
            user.CreateTime = DateTime.Now;
            user.Creator = long.Parse(currentUserId);
            var result = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 删除用户  软删除----将用户状态改为删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Transation]
        public async Task<long> DelUserAsync(long id, string currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("User ID does not exist");
            }
            var user = await _db.Users.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"No information found for user,userId is {id}");
            }

            var items = await _db.User_Role_RelationShips.Where(m => m.UserId == user.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Status = (int)DataStatus.Delete;
                    item.UpdateTime = DateTime.Now;
                    item.Updator = long.Parse(currentUserId);
                }
            }
            user.Status = (int)DataStatus.Delete;
            user.UpdateTime = DateTime.Now;
            user.Updator = long.Parse(currentUserId);
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载用户模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<UserDownloadTemplate> list = new List<UserDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载用户模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] UserParamsDTO userParams)
        {
            var result = _db.Users.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(userParams.Name))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Name));
            }
            if (!String.IsNullOrWhiteSpace(userParams.Code))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Code));
            }
            var userList = result.Adapt<List<UserExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("用户信息", userList);
        }

        /// <summary>
        /// 获取jwt
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public async Task<string> GetJwtDataAsync(string userCode)
        {
            List<Claim> claims = new List<Claim>();
            var currentUser = await _db.Users.Where(m => m.Code.Equals(userCode) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (currentUser == null)
            {
                throw new Exception($"{userCode} is not  Exist！");
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, currentUser.Code));
                claims.Add(new Claim("JWTVersion", currentUser.JWTVersion.ToString()));
                var items = await _db.User_Role_RelationShips.Where(m => m.UserId == currentUser.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.RoleCode));
                    }
                }
            }

            string key = _jwtOptionsSnapshot.Value.SigningKey.ToString();
            DateTime expires = DateTime.Now.AddSeconds(_jwtOptionsSnapshot.Value.ExpireSeconds);
            byte[] secBytes = Encoding.UTF8.GetBytes(key);
            var secKey = new SymmetricSecurityKey(secBytes);
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(claims: claims,
                expires: expires, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return jwt;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<User>> GetUserAsync([FromQuery] UserParamsDTO userParams)
        {
            var result = _db.Users.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(userParams.Name))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Name));
            }
            if (!String.IsNullOrWhiteSpace(userParams.Code))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Code));
            }
            return await result.ToListAsync();
        }

        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User> GetUserByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The user id parameter is empty");
            }
            var user = await _db.Users.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"No information found for User,id is {id}");
            }
            return user;
        }

        /// <summary>
        /// 分页查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        public async Task<BasePagination<User>> GetUserPaginationAsync([FromQuery] UserParamsDTO userParams)
        {
            var result = _db.Users.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(userParams.Name))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Name));
            }
            if (!String.IsNullOrWhiteSpace(userParams.Code))
            {
                result = result.Where(m => m.Name.StartsWith(userParams.Code));
            }
            return await PaginationService.PaginateAsync(result, userParams.PageIndex, userParams.PageSize);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [Transation]
        public async Task<string> ImportAsync(string path, string currentUserId)
        {
            var result = MiniExcelUtil.Import<UserDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断用户编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported user code");
            }
            //判断用户姓名有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported user name");
            }
            //判断用户性别有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Gender)))
            {
                throw new Exception("There is a null value in the imported user gebder");
            }
            //判断用户密码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Password)))
            {
                throw new Exception("There is a null value in the imported user password");
            }
            //判断用户编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("User code duplication");
            }
            var codeList = result.Select(m => m.Code).ToList();
            var items= await _db.Users.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (items != null && items.Count >0)
            {
                throw new Exception("User code already exists");
            }

            var data = result.Select(m => new User
            {
                Name = m.Name,
                Code = m.Code,
                Age = m.Age,
                Gender = m.Gender,
                Password = MD5EncryptionUtil.Encrypt(m.Password),
                Birth = m.Birth,
                Email = m.Email,
                Phone = m.Phone,
                Address = m.Address,
                Status = (int)DataStatus.Normal,
                Creator = long.Parse(currentUserId),
                Remark = m.Remark,
                CreateTime = DateTime.Now,
                JWTVersion = 0

            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import Users successful";
        }

        /// <summary>
        /// 根据用户编码查询用户信息
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User> GetUserByCodeAsync(string userCode)
        {
            if (string.IsNullOrWhiteSpace(userCode))
            {
                throw new Exception("Query parameter userCode is empty");
            }
            var user = await _db.Users.Where(m => m.Code.Equals(userCode) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"No information found for User,id is {userCode}");
            }
            return user;
        }

        /// <summary>
        /// 根据用户编码判断用户是否存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string userCode)
        {
            if (string.IsNullOrWhiteSpace(userCode))
            {
                throw new Exception("Query parameter userCode is empty");
            }
            var user = await _db.Users.Where(m => m.Code.Equals(userCode) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> LoginAsync(string userCode, string password)
        {
            var currentUser = await _db.Users.Where(m => m.Code.Equals(userCode) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (currentUser == null)
            {
                throw new Exception($"{userCode} is not  Exist！");
            }
            else
            {
                if (MD5EncryptionUtil.Decrypt(currentUser.Password).Equals(password))
                {
                    currentUser.JWTVersion++;
                    currentUser.UpdateTime = DateTime.Now;
                    currentUser.Updator = currentUser.Id;
                    await _db.SaveChangesAsync();

                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, currentUser.Code));
                    claims.Add(new Claim("JWTVersion", currentUser.JWTVersion.ToString()));
                    var items = await _db.User_Role_RelationShips.Where(m => m.UserId == currentUser.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
                    if (items != null && items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item.RoleCode));
                        }
                    }


                    string key = _jwtOptionsSnapshot.Value.SigningKey.ToString();
                    DateTime expires = DateTime.Now.AddSeconds(_jwtOptionsSnapshot.Value.ExpireSeconds);
                    byte[] secBytes = Encoding.UTF8.GetBytes(key);
                    var secKey = new SymmetricSecurityKey(secBytes);
                    var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
                    var tokenDescriptor = new JwtSecurityToken(claims: claims,
                        expires: expires, signingCredentials: credentials);
                    string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                    return jwt;
                }
                else
                {
                    return "AccessFailed";
                }
            }
        }
        /// <summary>
        /// 密码重置
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task<string> ReSetPasswordAsync(string userCode, string password, string newPassword, string currentUserId)
        {
            if (string.IsNullOrWhiteSpace(userCode) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newPassword))
            {
                throw new Exception("Password reset failed, user code, original password, and current password cannot be empty");
            }
            if (password.Equals(newPassword))
            {
                throw new Exception("Password reset failed, original password and current password are the same");
            }
            var user = await _db.Users.Where(m => m.Code.Equals(userCode)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            if (user.Status != (int)DataStatus.Normal)
            {
                throw new Exception("Abnormal user status");
            }
            user.Password = MD5EncryptionUtil.Encrypt(newPassword);
            user.UpdateTime = DateTime.Now;
            user.Updator = long.Parse(currentUserId);

            await _db.SaveChangesAsync();
            return "Password reset successful";
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <returns></returns>
        public async Task<string> UpdateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO, string currentUserId)
        {
            if (createOrUpdateUserDTO.Id <= 0)
            {
                throw new Exception("User ID does not exist");
            }
            var user = await _db.Users.Where(m => m.Id == createOrUpdateUserDTO.Id).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"No information found for user,userId is {createOrUpdateUserDTO.Id}");
            }
            if (user.Status != (int)DataStatus.Normal)
            {
                throw new Exception("Abnormal user status");
            }
            if (!string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Code))
            {
                if (await IsExistAsync(createOrUpdateUserDTO.Code))
                {
                    throw new Exception($"User code {createOrUpdateUserDTO.Code} already exists, duplicate creation is not allowed");
                }

                var items = await _db.User_Role_RelationShips.Where(m => m.UserId == user.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        item.UserCode = createOrUpdateUserDTO.Code;
                        item.UserName = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Name) ? user.Name : createOrUpdateUserDTO.Name;
                        item.Updator = long.Parse(currentUserId);
                    }
                }
                user.Code = createOrUpdateUserDTO.Code;
            }

            //基础信息更新
            user.Gender = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Gender) ? user.Gender : createOrUpdateUserDTO.Gender;
            user.Age = createOrUpdateUserDTO.Age == 0 ? user.Age : createOrUpdateUserDTO.Age;
            user.Name = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Name) ? user.Name : createOrUpdateUserDTO.Name;
            user.Address = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Address) ? user.Address : createOrUpdateUserDTO.Address;
            user.Birth = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Birth) ? user.Birth : createOrUpdateUserDTO.Birth;
            user.Email = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Email) ? user.Email : createOrUpdateUserDTO.Email;
            user.Phone = string.IsNullOrWhiteSpace(createOrUpdateUserDTO.Phone) ? user.Phone : createOrUpdateUserDTO.Phone;
            user.Remark = createOrUpdateUserDTO.Remark;
            user.Updator = long.Parse(currentUserId);
            user.UpdateTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return "Successfully updated user information";

        }

        /// <summary>
        /// 根据ids集合获取用户数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUserByIdsAsync(string ids)
        {
            var list = new List<User>();
            if (!string.IsNullOrWhiteSpace(ids)) 
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Users.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据codes集合获取用户数据
        /// </summary>
        /// <param name="codes"></param> 
        /// <returns></returns>
        public async Task<List<User>> GetUserByCodesAsync(string codes)
        {
            var list = new List<User>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Users.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }
    }
}
