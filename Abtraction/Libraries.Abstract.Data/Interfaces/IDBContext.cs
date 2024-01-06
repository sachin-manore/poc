
namespace Libraries.Abstract.Data
{
    public interface IDBContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="loginUserAccountId">Login User Account Id</param>
        /// <returns></returns>
        int SaveChanges(int loginUserAccountId, int createdBy = 0, int modifiedBy = 0);

        /// <summary>
        /// Save changes Asynchronously
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Save changes Asynchronously
        /// </summary>
        /// <param name="loginUserAccountId">Login User Account Id</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(int loginUserAccountId);

        
    }
}
