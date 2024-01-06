
namespace Libraries.Abstract.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Declarations
        private readonly AbstractDbContext _context;
        #endregion

        #region Constructor
        public Repository(AbstractDbContext context)
        {
            _context = context;

        }

        #endregion

        #region Properties

        //Returns an IQueryable instance for access to entities of the given type in the context
        public virtual IQueryable<T> Table => this.Entities;

        //Returns a DbSet instance for access to entities of the given type in the context
        protected virtual Microsoft.EntityFrameworkCore.DbSet<T>? Entities
        {
            get
            {
                return !Equals(_context, null) ? _context.Set<T>() : null;
            }
        }

        #endregion

        #region GetById Entity

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <typeparam name="TId">is a generic struct (eg: int, guid etc.) input</typeparam>
        /// <param name="id">is a primary key value to return entity.</param>
        /// <returns>return entity</returns>
        public virtual T GetById<TId>(TId id) where TId : struct => Entities.Find(id);

        /// <summary>
        /// Get entity by identifier Asynchronously
        /// </summary>
        /// <typeparam name="TId">is a generic struct (eg: int, guid etc.) input</typeparam>
        /// <param name="id">is a primary key value to return entity.</param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync<TId>(TId id) where TId : struct => await Entities.FindAsync(id);

        /// <summary>
        /// Get entity by identifier Asynchronously
        /// </summary>
        /// <param name="id">Is a Primary key value.</param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        #endregion

        #region Insert Entity
        // Insert entity
        public virtual T Insert(T entity)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Add(entity);
                int _result = _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //Remove added entity from objects for all the entities tracked by context.
                Entities.Remove(entity);

                throw;
            }
            return entity;
        }


        /// <summary>
        /// Insert entity Asynchronously
        /// </summary>
        /// <param name="entity">Is a entity data model entity</param>
        /// <returns></returns>
        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Remove added entity from objects for all the entities tracked by context.
                Entities.Remove(entity);

                throw;
            }
            return entity;
        }

        #endregion

        #region Update Entity
        /// <summary>
        /// Update entity 
        /// </summary>
        /// <param name="entity">Is a entity data model entity</param>
        /// <returns>Returns true or false</returns>
        public virtual bool Update(T entity)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);

                bool _result = _context.SaveChanges() > 0;


                return _result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// This method use to update record in database with login User Id.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="loginUserId">login User Id</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Update(T entity, int loginUserId)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }
               
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);

                bool _result = _context.SaveChanges() > 0;

                return _result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private object GetObjectKey(T entity)
       => typeof(T).GetProperty(GetEntityPrimaryKey<T>()).GetValue(entity, null);

        private string GetEntityPrimaryKey<TEntity>() where TEntity : class
        {
            if (_context.Model.FindEntityType(typeof(T)).FindPrimaryKey() != null)
                return _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).FirstOrDefault().ToString();

            else return "";
        }

        #endregion


        // Delete entity
        public virtual bool Delete(T entity)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Remove(Entities.Find(GetObjectKey(entity)));
                bool _result = _context.SaveChanges() > 0;

                return _result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete entity Asynchronously
        /// </summary>
        /// <param name="entity">Is a entity data model entity</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                if (Equals(entity, null))
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Remove(await _context.Set<T>().FindAsync(entity));
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {

                throw;
            }
        }

    }

}