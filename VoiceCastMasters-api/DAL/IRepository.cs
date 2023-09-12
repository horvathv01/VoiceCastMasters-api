using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public interface IRepository<T>
{
    Task<bool> Add(T entity);
    Task<T?> GetById(long id);
    Task<IEnumerable<Actor>?> GetListByIds(List<long> ids);
    Task<bool> Update(long id, T entity);
    Task<bool> Delete(long id);
    Task<IEnumerable<T>> GetAll();

    Task<T?> GetByEmail(string email);
}