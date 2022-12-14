namespace ContactManagement.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllSoftDeleted();
        void Update(TEntity obj);
        void Remove(long id);
        int SaveChanges();
    }
}
