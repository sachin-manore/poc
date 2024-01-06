
namespace Libraries.Abstract.BaseController
{
    public abstract class BaseController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
        }

    }
}
