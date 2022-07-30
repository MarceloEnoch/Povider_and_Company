using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Povider_and_Company.Domain
{
    public class Fornecedor
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }  
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; } 
        
        public IEnumerable<EmpresaFornecedor> EmpresasFornecedores { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}