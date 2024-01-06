using ServiceName.Api.Model.Responses;

namespace ServiceName.Service.Helper
{
    public static class ModelMapper
    {
        //Map response json to model
        public static List<WebClientResponseModel> ResponseToDto(string response)
        {
            dynamic jsonData = JsonConvert.DeserializeObject(response);

            List<WebClientResponseModel> dataModel = new List<WebClientResponseModel>();

            foreach (var item in jsonData.response)
            {
                dataModel.Add(new WebClientResponseModel
                {
                    Fixture = JsonConvert.DeserializeObject<FixtureDtoModel>(Convert.ToString(item.fixture)),

                    League = JsonConvert.DeserializeObject<LeagueDtoModel>(Convert.ToString(item.league))
                });
            }
            return dataModel;
        }

        //Map Dto to entity
        public static fixture ToFixtureEntity(FixtureDtoModel model)
        {
            if (model != null)
            {
                return new fixture
                {
                    date = model.Date,
                    externalid = model.Id,
                    referee = model.Referee,
                    timezone = model.Timezone,
                    timestamp = model.Timestamp
                };
            }
            return null;
        }

        //Map etity to response model
        public static FixtureListResponse ToFixtureListResponse(List<fixture> fixtures)
        {
            if (fixtures != null)
            {
                FixtureListResponse response = new FixtureListResponse { Fixtures = new List<FixtureDtoModel>() };
                foreach (fixture fixture in fixtures)
                {
                    response.Fixtures.Add(new FixtureDtoModel
                    {
                        Date = fixture.date,
                        ExternalId = fixture.externalid,
                        Id = fixture.id,
                        Referee = fixture.referee,
                        Timestamp = fixture.timestamp,
                        Timezone = fixture.timezone,
                        
                    });
                }

                return response;
               
            }
            return null;
        }
    }
}
