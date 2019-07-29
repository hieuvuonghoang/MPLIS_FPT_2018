using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Params
{
    public static class Config
    {
        private static double CookieTimeout = 15; //Default value
        private static double TokenTimeout = 4; //Default value
        private static double DataTimeOut = 15;
        private static string SecurityKey = "";
        private static string SSOSiteUrl = "";
        private static string Internal_SSOSiteUrl = "";
        private static string LoginUrl = "";
        private static string DefaultUrl = "";
        private static string filepath = "";

        /// <summary>
        /// Token timeout value in minutes in web.config
        /// Default value is 4 hours
        /// </summary>
        public static double AUTH_TOKEN_TIMEOUT_IN_HOURS
        {
            get
            {
                if (TokenTimeout == 4)
                {
                    string StrTokenTimeout = ConfigurationManager.AppSettings[SSOConstants.Configuration.AUTH_TOKEN_TIMEOUT_IN_HOURS];
                    TokenTimeout = 4;
                    double.TryParse(StrTokenTimeout, out TokenTimeout);
                }

                return TokenTimeout;
            }
        }

        /// <summary>
        /// Cookie timeout value in minutes in web.config
        /// Default value is 30 minutes
        /// </summary>
        public static double AUTH_COOKIE_TIMEOUT_IN_MINUTES
        {
            get
            {
                if (CookieTimeout == 15)
                {
                    string StrCookieTimeout = ConfigurationManager.AppSettings[SSOConstants.Configuration.AUTH_COOKIE_TIMEOUT_IN_MINUTES];
                    CookieTimeout = 30;
                    double.TryParse(StrCookieTimeout, out CookieTimeout);
                }

                return CookieTimeout;
            }
        }

        /// <summary>
        /// Cookie timeout value in minutes in web.config
        /// Default value is 30 minutes
        /// </summary>
        public static double AUTH_REQUEST_DATA_TIMEOUT_IN_MINUTES
        {
            get
            {
                if (DataTimeOut == 15)
                {
                    string strDataTimeOut = ConfigurationManager.AppSettings[SSOConstants.Configuration.AUTH_REQUEST_DATA_TIMEOUT_IN_MINUTES];
                    DataTimeOut = 30;
                    double.TryParse(strDataTimeOut, out DataTimeOut);
                }

                return DataTimeOut;
            }
        }

        /// <summary>
        /// Cookie timeout value in minutes in web.config
        /// Default value is 30 minutes
        /// </summary>
        public static string SECURITY_KEY
        {
            get
            {
                if (SecurityKey.Equals(""))
                {
                    SecurityKey = ConfigurationManager.AppSettings[SSOConstants.Configuration.SECURITY_KEY];
                }

                return SecurityKey;
            }
        }

        ///// <summary>
        ///// Sliding expiration
        ///// </summary>
        //public static bool SLIDING_EXPIRATION
        //{
        //    get
        //    {
        //        string StrSlidingExpiration = ConfigurationManager.AppSettings[SSOConstants.Configuration.SLIDING_EXPIRATION];
        //        bool SlidingExpiration = true; //Default value
        //        bool.TryParse(StrSlidingExpiration, out SlidingExpiration);

        //        return SlidingExpiration;
        //    }
        //}

        /// <summary>
        /// Sliding expiration
        /// </summary>
        public static string INTERNAL_SSO_SITE_URL
        {
            get
            {
                if(Internal_SSOSiteUrl == null || Internal_SSOSiteUrl.Equals(""))
                    Internal_SSOSiteUrl = ConfigurationManager.AppSettings[SSOConstants.Configuration.INTERNAL_SSO_SITE_URL];
                
                return Internal_SSOSiteUrl;
            }
        }

        public static string SSO_SITE_URL
        {
            get
            {
                if (SSOSiteUrl == null || SSOSiteUrl.Equals(""))
                    SSOSiteUrl = ConfigurationManager.AppSettings[SSOConstants.Configuration.SSO_SITE_URL];

                return SSOSiteUrl;
            }
        }

        /// <summary>
        /// DefaultUrl
        /// </summary>
        public static string DEFAULT_URL
        {
            get
            {
                if (DefaultUrl == null || DefaultUrl.Equals(""))
                    DefaultUrl = ConfigurationManager.AppSettings[SSOConstants.Configuration.DEFAULT_URL];

                return DefaultUrl;
            }
        }
        public static string FILE_UPLOAD_PATH
        {
            get
            {
                if (filepath==null||filepath.Equals(""))
                {
                    filepath = ConfigurationManager.AppSettings[SSOConstants.Configuration.FILE_UPLOAD_PATH];
                }

                return filepath;
            }
        }
    }
}
