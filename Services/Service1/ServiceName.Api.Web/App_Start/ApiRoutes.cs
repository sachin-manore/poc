using Microsoft.AspNetCore.Routing.Constraints;

using Swashbuckle.AspNetCore.SwaggerGen.ConventionalRouting;

namespace ServiceName.Api.Web.App_Start
{
    public class ApiRoutes
    {
        /// <summary>
        /// Map Controller Routes
        /// </summary>
        /// <param name="endpoints"></param>
        public static void MapControllerRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "homeindex",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
                );

            endpoints.MapControllerRoute(
               name: "fixture-sync",
               pattern: "sport/syncdatafromapi",
               defaults: new { controller = "Sport", action = "SyncDataFromApi" },
               constraints: new { https = new HttpMethodRouteConstraint(HttpMethod.Get.ToString()) }
               );
            endpoints.MapControllerRoute(
               name: "fixture-sync",
               pattern: "sport/getfixtures",
               defaults: new { controller = "Sport", action = "GetFixture" },
               constraints: new { https = new HttpMethodRouteConstraint(HttpMethod.Get.ToString()) }
               );



            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            ConventionalRoutingSwaggerGen.UseRoutes(endpoints);
        }
    }
}
