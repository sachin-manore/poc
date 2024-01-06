

namespace Libraries.Abstract.Data
{
    public interface IRepository<T>
    {
        /// <summary>
        ///Returns an IQueryable instance for access to entities of the given type in the context
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Get Entity by its Primary Key.
        /// </summary>
        /// <typeparam name="TId">DataType for Primary Key</typeparam>
        /// <param name="id">Primary Key value</param>
        /// <returns>returns T</returns>
        T GetById<TId>(TId id) where TId : struct;

        /// <summary>
        /// Get Entity by its Primary Key Asynchronously.
        /// </summary>
        /// <typeparam name="TId">DataType for Primary Key</typeparam>
        /// <param name="id">Primary Key value</param>
        /// <returns>returns Task<T></returns>
        Task<T> GetByIdAsync<TId>(TId id) where TId : struct;

        /// <summary>
        /// Get Entity by its Primary Key Asynchronously.
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>returns Task<T></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Insert entity Asynchronously.
        /// </summary>
        /// <param name="entity">Entity</param>
        T Insert(T entity);


        /// <summary>
        /// Insert entity 
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<T> InsertAsync(T entity);


        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Update(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="loginUserId">login User Id</param>
        bool Update(T entity, int loginUserId);


        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Delete(T entity);

        /// <summary>
        /// Delete entity Asynchronously.
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<bool> DeleteAsync(T entity);

    }
}
