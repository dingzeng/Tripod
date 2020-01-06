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
    /// API״̬��
    /// </summary>
    public enum ApiCode
    {
        /// <summary>
        /// �Ƿ�Token
        /// </summary>
        ILLEGAL_TOKEN = 50008,

        /// <summary>
        /// Ȩ�ޱ��ܾ�
        /// </summary>
        PERMISSION_DENIED = 500010,

        /// <summary>
        /// Token����
        /// </summary>
        TOKEN_EXPIRED = 50014,

        /// <summary>
        /// �����ͻ��˵�¼
        /// </summary>
        OTHER_CLIENTS_LOGGERD_IN = 50012,

        /// <summary>
        /// ��֤ʧ��
        /// </summary>
        VALIDATTION_FAILED = 50001,

        /// <summary>
        /// ִ��ʧ��
        /// </summary>
        FAILED = 50000,

        /// <summary>
        /// �ɹ�
        /// </summary>
        SUCCESS = 20000,
    }
}