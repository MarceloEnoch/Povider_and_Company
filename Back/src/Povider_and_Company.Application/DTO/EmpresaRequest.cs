using System;
using System.Collections.Generic;

namespace Povider_and_Company.Domain
{
    public class EmpresaRequest
    {        
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }            
    }
}