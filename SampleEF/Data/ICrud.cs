namespace SampleEF.Data
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Insert(T obj);
        T Update(T obj);
        void Delete(int id);
    }
}
