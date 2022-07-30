using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Povider_and_Company.Domain
{
    public class EmpresaFornecedor
    {
        public int Id { get; set; }   

        public int IdEmpresa { get; set; }        
        public int IdFornecedor { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }   

        public Fornecedor Fornecedor { get; set; }
        public Empresa Empresa { get; set; }
 
    }
}