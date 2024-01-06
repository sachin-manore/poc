
namespace Libraries.Abstract.Data
{
    public class AbstractDbContext : DbContext
    {

        protected AbstractDbContext() : base()
        {
        }

        public AbstractDbContext(DbContextOptions options) : base(options)
        {
        }


      
    }
}
