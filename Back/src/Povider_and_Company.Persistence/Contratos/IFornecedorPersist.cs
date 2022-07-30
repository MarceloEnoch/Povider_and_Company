using System.Threading.Tasks;
using Povider_and_Company.Domain;

namespace Povider_and_Company.Persistence.Contratos
{
    public interface IFornecedorPersist : IGeralPersist
    {
        Task<Fornecedor[]> GetAll(DateTime data, string nome, string documento);
    }
}