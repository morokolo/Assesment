using System;
using System.Diagnostics;

namespace Oplay.Services.Constants
{
    public class ServiceURLs
    {
        private static string _baseURL = "";
        public const string BaseURLDebug = "https://techtestapi.azurewebsites.net/api/";
        public const string BaseURLStaging = "https://techtestapi.azurewebsites.net/api/";
        public const string BaseURLProduction = "https://techtestapi.azurewebsites.net/api/";


        public static string BaseURL
        {
            get
            {
                return _baseURL;
            }
        }

        #region Endpoints

        public const string UserEmployeeEndpoint = "People/";

        #endregion

        public static void InitializeSettings()
        {
            SetDebugEnvironment();
            SetStagingEnvironment();
            SetProductionEnvironment();
        }

        [Conditional("DEBUG")]
        public static void SetDebugEnvironment()
        {
            _baseURL = BaseURLDebug;
        }

        [Conditional("STAGING")]
        public static void SetStagingEnvironment()
        {
            _baseURL = BaseURLStaging;
        }

        [Conditional("RELEASE")]
        public static void SetProductionEnvironment()
        {
            _baseURL = BaseURLProduction;
        }
    }
}
