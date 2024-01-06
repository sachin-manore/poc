namespace Libraries.Abstract.BaseService
{
    public abstract class BaseService
    {
        #region Protected Variable
        protected readonly IServiceProvider _serviceProvider;
        #endregion

        #region Constructor
        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion
    }
}
