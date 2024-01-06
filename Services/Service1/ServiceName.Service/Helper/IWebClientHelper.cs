using ServiceName.Api.Model.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceName.Service.Helper
{
    public interface IWebClientHelper
    {
        /// <summary>
        /// This method is use to get the client api response 
        /// </summary>
        /// <param name="webClientKeysModel">web client kays model contains url, apikey and api host properties</param>
        /// <returns></returns>
        string? GetClientResponse(WebClientKeysModel webClientKeysModel);
        
    }
}
