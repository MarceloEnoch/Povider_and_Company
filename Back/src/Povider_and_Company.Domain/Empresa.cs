using System;
using System.Collections.Generic;

namespace Povider_and_Company.Domain
{
    public class Empresa
    {
        public int Id { get; set; }        
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; } 
        public IEnumerable<EmpresaFornecedor> EmpresaFornecedores { get; set; }       
    }
}