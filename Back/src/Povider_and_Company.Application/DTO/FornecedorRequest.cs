using System;
using System.Collections.Generic;

namespace Povider_and_Company.Domain
{
    public class FornecedorRequest
    {        
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<EmpresaRequest> Empresas { get; set; }  

        public List<TelefoneRequest> Telefones { get; set; }    
    }

    
}