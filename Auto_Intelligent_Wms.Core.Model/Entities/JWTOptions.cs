namespace Auto_Intelligent_Wms.Core.Model.Entities
{
    public class JWTOptions
    {
        /// <summary>
        /// 密钥
        /// </summary>
        public string SigningKey { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public long ExpireSeconds { get; set; }
    }
}
