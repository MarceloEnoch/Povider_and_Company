using System.Threading.Tasks;

namespace Povider_and_Company.Persistence.Contratos
{
    public interface IGeralPersist
    {
        void UseAdd<T>(T entity) where T : class;
        void UseUpdate<T>(T entity) where T : class;
        void UseDelete<T>(T entity) where T : class;
        void UseDeleteRange<T>(T[] entity) where T : class;
        Task<bool> UseSaveChangesAsync();
    }
}