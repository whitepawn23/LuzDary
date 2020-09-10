namespace DemoLuz.DataAccess.Core
{
    public interface IUnitOfWork
    {
        void ExecuteSqlCommand(string command);

        IRepository<T> Repository<T>()
        where T : class;

        void SaveChanges();

        void SetAutoDetectChanges(bool enabled);
    }
}
