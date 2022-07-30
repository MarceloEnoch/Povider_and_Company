using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Povider_and_Company.Domain;
using Povider_and_Company.Persistence.Contextos;
using Povider_and_Company.Persistence.Contratos;
using Povider_and_Company.Persistence;

namespace Povider_and_Company.Persistence
{
    public class FornecedorPersist : GeralPersist, IFornecedorPersist
    {
        public FornecedorPersist(Povider_and_Company_Context context) : base(context)
        {

        }

        public async Task<Fornecedor[]> GetAll(DateTime data, string nome, string documento)
        {
            IQueryable<Fornecedor> query = context.fornecedores.AsNoTracking()
                             .Where(f => f.DataCadastro == data || 
                                         f.Nome.Contains(nome) || 
                                         f.Documento.Contains(documento));

                return await query.ToArrayAsync();
        }

    }
}