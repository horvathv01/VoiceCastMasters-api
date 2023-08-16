namespace VoiceCastMasters_api.DAL;

public interface IRepository<T>
{
    bool Add(T entity);
    T GetById(long id);
    bool Update(long id, T entity);
    bool Delete(long id);
    IEnumerable<T> GetAll();
}