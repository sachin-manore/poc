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
        public static Fixture ToFixtureEntity(FixtureDtoModel model)
        {
            if (model != null)
            {
                return new Fixture
                {
                    Date = model.Date,
                    ExternalId = model.Id,
                    Referee = model.Referee,
                    Timezone = model.Timezone,
                    Timestamp = model.Timestamp
                };
            }
            return null;
        }

        //Map etity to response model
        public static FixtureListResponse ToFixtureListResponse(List<Fixture> fixtures)
        {
            if (fixtures != null)
            {
                FixtureListResponse response = new FixtureListResponse { Fixtures = new List<FixtureDtoModel>() };
                foreach (Fixture fixture in fixtures)
                {
                    response.Fixtures.Add(new FixtureDtoModel
                    {
                        Date = fixture.Date,
                        ExternalId = fixture.ExternalId,
                        Id = fixture.Id,
                        Referee = fixture.Referee,
                        Timestamp = fixture.Timestamp,
                        Timezone = fixture.Timezone,
                        
                    });
                }

                return response;
               
            }
            return null;
        }
    }
}
