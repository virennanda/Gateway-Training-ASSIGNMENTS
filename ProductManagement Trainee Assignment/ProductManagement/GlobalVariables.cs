using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ProductManagement.Resources.Constants;

namespace ProductManagement
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient=new HttpClient();
        
        static GlobalVariables()
        {
            WebApiClient.BaseAddress=new Uri("http://localhost:49956/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
           WebApiClient.DefaultRequestHeaders.Add("X-ApiKey",ApiInfoHeaderData.X_ApiKey);
           WebApiClient.DefaultRequestHeaders.Add("Authorization","Basic "+ApiInfoHeaderData.Authorization);
        }
    }
}