using System;

namespace Povider_and_Company.Domain
{
    public class Telefone
    {
        public int Id { get; set; }
        public int IdFornecedor { get; set; }    
                  
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }   
        public Fornecedor Fornecedor { get; set; }     
    }
} 