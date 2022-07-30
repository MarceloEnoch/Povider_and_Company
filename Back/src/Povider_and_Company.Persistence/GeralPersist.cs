using System.Threading.Tasks;
using Povider_and_Company.Persistence.Contextos;
using Povider_and_Company.Persistence.Contratos;

namespace Povider_and_Company.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        protected readonly Povider_and_Company_Context context;

        public GeralPersist(Povider_and_Company_Context context)
        {
            this.context = context;
        }
        public void UseAdd<T>(T entity) where T : class
        {
            context.AddAsync(entity);
        }

        public void UseUpdate<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void UseDelete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public void UseDeleteRange<T>(T[] entityArray) where T : class
        {
            context.RemoveRange(entityArray);
        }

        public async Task<bool> UseSaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}