using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Params
{
    public class SSOConstants
    {
        public SSOConstants()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Url Parameter constant class
        /// </summary>
        public class UrlParams
        {
            public const string TOKEN = "Token";
            public const string ACTION = "Action";
            public const string RETURN_URL = "ReturnUrl";
        }

        /// <summary>
        /// Constant class for Cookie
        /// </summary>
        public class Cookie
        {
            public const string AUTH_COOKIE = "VILISUserLoginInfo";
            public const string SLIDING_EXPIRATION = "SLIDING_EXPIRATION";
        }

        /// <summary>
        /// Constant class for Parameter values
        /// </summary>
        public class ParamValues
        {
            public const string LOGOUT = "Logout";
            public const string LOGIN = "Login";
        }

        /// <summary>
        /// Constant class for Configuration keys
        /// </summary>
        public class Configuration
        {
            public const string AUTH_COOKIE_TIMEOUT_IN_MINUTES = "AUTH_COOKIE_TIMEOUT_IN_MINUTES";
            public const string AUTH_TOKEN_TIMEOUT_IN_HOURS = "AUTH_TOKEN_TIMEOUT_IN_HOURS";
            public const string AUTH_REQUEST_DATA_TIMEOUT_IN_MINUTES = "AUTH_REQUEST_DATA_TIMEOUT_IN_MINUTES";
            public const string SECURITY_KEY = "SECURITY_KEY";
            public const string INTERNAL_SSO_SITE_URL = "INTERNAL_SSO_SITE_URL";
            public const string SSO_SITE_URL = "SSO_SITE_URL";
            public const string DEFAULT_URL = "DEFAULT_URL";
            public const string FILE_UPLOAD_PATH = "FILE_UPLOAD_PATH";

        }

        /// <summary>
        /// Constant class for Session keys
        /// </summary>
        public class SessionParams
        {
            public const string DO_NOT_REDIRECT = "DO_NOT_REDIRECT";
        }

        /// <summary>
        /// Constant class for SSO clients call API services
        /// </summary>
        public class SSOServicesParams
        {
            public const string GET_USER_INFORS = "/api/AuthService/getUserInfors";
            public const string GET_USER_STATUS = "/api/AuthService/getUserStatus";
            public const string UPDATE_COOKIE = "/api/AuthService/UpdateCookie";
            public const string LOGOUT_USER = "/api/AuthService/LogoutUser";
            public const string UPDATE_USER = "/api/UserManager/UpdateUser";
            //public const string AUTHENTICATE = "Authenticate";
        }

        /// <summary>
        /// Constant class for SSO clients call authenticate pages
        /// </summary>
        public class SSOPageParams
        {
            public const string LOGIN_PAGE = "/Authenticate/Login";
            public const string LOGOUT = "/Authenticate/Logout";
        }
    }
}
