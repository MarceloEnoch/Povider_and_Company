using System.Threading.Tasks;
using Povider_and_Company.Domain;

namespace Povider_and_Company.Application.Contratos
{
    public interface IFornecedorService
    {
        Task<Fornecedor> Add (FornecedorRequest request);
        Task<Fornecedor> Update (FornecedorRequest request);
        Task Delete (int IdFornecedor);
        Task<FornecedorRequest[]> GetAll(FornecedorFiltroRquest filtro);
    }
}