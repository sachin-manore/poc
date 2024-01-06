
namespace ServiceName.Service.IService
{
    public interface ISportService
    {
        /// <summary>
        /// This method is used to fetch data from the sport API and sync with application database
        /// </summary>
        /// <returns>trturn tru or false</returns>
        Task<bool> SyncDataFromApi();

        /// <summary>
        /// This method is used to insert data in to application db from client api 
        /// </summary>
        /// <param name="responseString"></param>
        /// <returns></returns>
        Task<bool> SyncDataToDB(string responseString);

        /// <summary>
        /// This method is used to fetch the fixture recored from application db
        /// </summary>
        /// <returns>return FixtureListResponse</returns>
        Task<FixtureListResponse> GetFixtureFromDb();
        
        
    }
}
