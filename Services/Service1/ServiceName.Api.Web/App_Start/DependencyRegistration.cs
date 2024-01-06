using Libraries.Common.Event;

using ServiceName.Service.Helper;
using ServiceName.Service.IService;
using ServiceName.Service.Service;

namespace ServiceName.Api.Web.App_Start
{
    public static class DependencyRegistration
    {
        public static void RegisterDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISportService, SportService>();
            builder.Services.AddScoped<IWebClientHelper, WebClientHelper>();
            builder.Services.AddTransient<IEventPublisher, EventPublisher>();
           
        }
    }
}
