using System;

namespace Tripod.Application.AdminApi
{
    public class ApiException : Exception
    {
        public ApiCode Code { get; set; }

        public ApiException() { }

        public ApiException(ApiCode code)
            : this(code, "")
        {

        }

        public ApiException(string message)
            : this(ApiCode.FAILED, message)
        {

        }

        public ApiException(ApiCode code, string message)
            : base(message)
        {
            this.Code = code;
        }
    }

    /// <summary>
    /// API状态码
    /// </summary>
    public enum ApiCode
    {
        /// <summary>
        /// 非法Token
        /// </summary>
        ILLEGAL_TOKEN = 50008,

        /// <summary>
        /// 权限被拒绝
        /// </summary>
        PERMISSION_DENIED = 500010,

        /// <summary>
        /// Token过期
        /// </summary>
        TOKEN_EXPIRED = 50014,

        /// <summary>
        /// 其他客户端登录
        /// </summary>
        OTHER_CLIENTS_LOGGERD_IN = 50012,

        /// <summary>
        /// 验证失败
        /// </summary>
        VALIDATTION_FAILED = 50001,

        /// <summary>
        /// 执行失败
        /// </summary>
        FAILED = 50000,

        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 20000,
    }
}