
namespace ServiceName.Service.Helper
{
    public class WebClientHelper : IWebClientHelper
    {
        protected readonly ILogger<WebClientHelper> _logger;
        public WebClientHelper(ILogger<WebClientHelper> logger)
        {
            _logger = logger;
        }
        public virtual string? GetClientResponse(WebClientKeysModel webClientKeysModel)
        {
            if (webClientKeysModel != null)
            {
                //check required keys and throw error
                if (string.IsNullOrEmpty(webClientKeysModel.url))
                    throw new ArgumentNullException("url");
                if (string.IsNullOrEmpty(webClientKeysModel.apiKey))
                    throw new ArgumentNullException("apiKey");
                if (string.IsNullOrEmpty(webClientKeysModel.apiHost))
                    throw new ArgumentNullException("apiHost");

                //rest client 
                var client = new RestClient(webClientKeysModel.url);

                //create request and headers
                var request = new RestRequest();
                request.AddHeader("x-rapidapi-key", webClientKeysModel.apiKey);
                request.AddHeader("x-rapidapi-host", webClientKeysModel.apiHost);

                //add parameters
                if(webClientKeysModel.param!=null)
                {
                    foreach(var p in webClientKeysModel.param)
                    {
                        request.AddParameter(p.Key, p.Value);
                    }
                }
                

                try
                {
                    //rest client call
                    RestResponse response = client.Execute(request);

                    if (response != null)
                    {
                        return response.Content;
                    }
                    return null;
                }

                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }
            else
                throw new ArgumentNullException("parameter should not be null");

            return null;

        }
    }
}
