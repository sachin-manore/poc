

using Libraries.Common.Exceptions;

using ServiceName.Api.Model.Responses;

namespace ServiceName.Service.Service
{
    public class SportService : ISportService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebClientHelper _webClientHelper;
        private readonly IConfiguration _configuration;
        protected readonly IRepository<fixture> _fixtureRepository;
        public SportService(IServiceProvider serviceProvider, IWebClientHelper webClientHelper, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _webClientHelper = webClientHelper;
            _configuration = configuration;
            _fixtureRepository = new Repository<fixture>(serviceProvider.GetService<Poc_Entities>());
        }

        public Task<bool> SyncDataFromApi()
        {
            //get reqest headers
            var model = GetApiSetting();

            //Build parameters
            model.param = BuildParameter();

            //webclient call
            string? response = _webClientHelper.GetClientResponse(model);

            //chek if response is not null and not contains any error 
            if (response != null)
            {
                SyncDataToDB(response);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public Task<bool> SyncDataToDB(string responseString)
        {
            //Mapping response to model
            var dtoModel = ModelMapper.ResponseToDto(responseString);

            if (dtoModel != null)
            {
                //TODO - need to be implement bulk insert, for now as a example recored inserted using foreach
                foreach (var item in dtoModel)
                {

                    var fixtureTable = _fixtureRepository.Insert(ModelMapper.ToFixtureEntity(item.Fixture));
                }
            }

            return Task.FromResult(true);
        }

        public Task<FixtureListResponse> GetFixtureFromDb()
        {
            //Get recored from table
            List<fixture> _fixtures = _fixtureRepository.Table.ToList();


            if (_fixtures.Any())
            {
                return Task.FromResult(ModelMapper.ToFixtureListResponse(_fixtures));
            }
            //raised user defined exception 
            throw new CustomException(100, "Recored not found");
        }

        /// <summary>
        /// Build request headers  
        /// </summary>
        /// <returns>return WebClientKeysModel model</returns>
        private WebClientKeysModel GetApiSetting()
        {
            //Read application setting config
            IConfigurationSection configurationSection = _configuration.GetSection("appsettings");


            return new WebClientKeysModel()
            {
                url = configurationSection["IntegrationEnpoint"],
                apiKey = configurationSection["IntegrationApiKey"],
                apiHost = configurationSection["IntegrationApiHost"]

            };
        }

        /// <summary>
        /// Building parameter for request 
        /// </summary>
        /// <returns>returns key pair Dictionary</returns>
        private Dictionary<string, string> BuildParameter()
        {
            var param = new Dictionary<string, string>();
            param.Add("date", "2023-12-20");

            return param;

        }


    }
}
