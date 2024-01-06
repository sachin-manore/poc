namespace ServiceName.Api.Core.Controllers
{
    public class SportController : BaseController
    {
      
        #region Private Variables
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SportController> _logging;
        private readonly IEventPublisher _eventPublisher;

        private readonly ISportService _sporteService;
        #endregion

        #region Constructor 
        public SportController(IServiceProvider serviceProvider, ISportService sporteService, ILogger<SportController> logger, IEventPublisher eventPublisher) : base(serviceProvider)
        {
            _sporteService= sporteService;
            _serviceProvider = serviceProvider;
            _logging = logger;
            _eventPublisher = eventPublisher;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get and sync data from integration api to application database
        /// </summary>
        /// <returns>true or false response</returns>
        [HttpGet]
        [Produces(typeof(TrueFalseResponse))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Indicates that the request is successfully executed and the response body contains the requested data.", typeof(TrueFalseResponse))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Indicates that the request is successfully executed, but the response body does not contain any data.", typeof(ErrorDetail))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Indicates that an error occurred on the server.", typeof(ErrorDetail))]
        public async Task<ActionResult> SyncDataFromApi()
        {
            try
            {
                //Sync data from sport api 
                bool created = await _sporteService.SyncDataFromApi();
                if (created)
                {
                    _eventPublisher.PublishEvent<TrueFalseResponse>(new TrueFalseResponse { IsSuccess = true });
                }
                return  Ok(new TrueFalseResponse { IsSuccess = created });
            }
            catch (CustomException ex)
            {
                _logging.LogError(ex, "Sport API custom  warning message");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logging.LogError(ex, ex.Message);
                return BadRequest();

            }
        }


        /// <summary>
        /// Get fixtures from application db
        /// </summary>
        /// <returns>list of fixtures</returns>
        [HttpGet]
        [Produces(typeof(FixtureListResponse))]
        [SwaggerResponse((int)HttpStatusCode.OK, "Indicates that the request is successfully executed and the response body contains the requested data.", typeof(FixtureListResponse))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Indicates that the request is successfully executed, but the response body does not contain any data.", typeof(ErrorDetail))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Indicates that an error occurred on the server.", typeof(ErrorDetail))]
        public async Task<ActionResult> GetFixture()
        {
            try
            {
                //get data from sport service 
                var data = await _sporteService.GetFixtureFromDb();
                if (data!=null)
                {
                    _eventPublisher.PublishEvent<FixtureListResponse>(data);
                }
                return Ok(data);
            }
            catch (CustomException ex)
            {
                _logging.LogError(ex, "Sport API custom  warning message");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logging.LogError(ex, ex.Message);
                return BadRequest();

            }
        }

        #endregion
    }
}
