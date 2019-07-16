namespace Persistence
{
    public interface IStorage
    {
        void Add<T>(T entity) where T : class;
    }
}