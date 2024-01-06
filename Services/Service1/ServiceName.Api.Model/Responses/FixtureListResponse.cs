using Libraries.Abstract.Models.Responses;

using ServiceName.Api.Model.Models;

namespace ServiceName.Api.Model.Responses
{
    public class FixtureListResponse : BaseListResponse
    {
        public List<FixtureDtoModel> Fixtures { get; set; }
    }
}
