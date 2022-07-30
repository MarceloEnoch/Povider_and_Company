using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Povider_and_Company.Application.Contratos;
using Povider_and_Company.Domain;
using Povider_and_Company.Persistence.Contratos;

namespace Povider_and_Company.Application
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorPersist fornecedorPersist;
        private readonly IGeralPersist empresaPersist;
        private readonly IGeralPersist empresaFornecedorPersist;
        private readonly IGeralPersist telefonePersist;

        public FornecedorService(IFornecedorPersist fornecedorPersist, IGeralPersist empresaPersist,
        IGeralPersist empresaFornecedorPersist, IGeralPersist telefoneEmpresaPersist)
        {
            this.fornecedorPersist = fornecedorPersist;
            this.empresaPersist = empresaPersist;
            this.empresaFornecedorPersist = empresaFornecedorPersist;
            this.telefonePersist = telefoneEmpresaPersist;

        }
        public async Task<Fornecedor> Add(FornecedorRequest modelo)
        {
            Fornecedor fornecedor = null;

            try
            {
                fornecedor = new Fornecedor();
                fornecedor.Documento = modelo.Documento;
                fornecedor.RG = modelo.Documento;
                fornecedor.DataNascimento = modelo.DataNascimento;
                fornecedor.Nome = modelo.Nome;
                fornecedor.DataCadastro = DateTime.Now;
                fornecedor.DataAtualizacao = DateTime.Now;  

                fornecedorPersist.UseAdd<Fornecedor>(fornecedor);

                Empresa empresa = null;
                if (modelo.Empresas != null)
                {
                    empresa = AddEmpresa(modelo);
                }

                if (modelo.Empresas != null)
                {
                    AddEmpresaFornecedor(fornecedor, empresa);
                }

                if (modelo.Telefones != null)
                {
                    foreach (var item in modelo.Telefones)
                    {
                        AddTelefone(fornecedor, item);
                    }
                }

                await fornecedorPersist.UseSaveChangesAsync();

                return fornecedor;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(int IdFornecedor)
        {
            throw new NotImplementedException();
        }

        public async Task<FornecedorRequest[]> GetAll(FornecedorFiltroRquest filtro)
        {
            List< FornecedorRequest > listRequests = new List<FornecedorRequest>();

            var listFornecedor = await fornecedorPersist.GetAll(filtro.DataCadastro, filtro.Nome, filtro.Documento);

            foreach (var fornecedor in listFornecedor)
            {
                FornecedorRequest request = new FornecedorRequest();
                request.RG = fornecedor.RG;
                request.Nome = fornecedor.Nome;
                request.Documento = fornecedor.Documento;
                request.DataNascimento = fornecedor.DataNascimento;

                request.Empresas = new List<EmpresaRequest>();

                foreach (var empresaFornecedor in fornecedor.EmpresasFornecedores)
                {
                    EmpresaRequest empresa = new EmpresaRequest();
                    empresa.UF = empresaFornecedor.Empresa.UF;
                    empresa.NomeFantasia = empresaFornecedor.Empresa.NomeFantasia;
                    empresa.CNPJ = empresaFornecedor.Empresa.CNPJ;

                    request.Empresas.Add(empresa);
                }

                foreach (var telefone in fornecedor.Telefones)
                {
                    TelefoneRequest telefoneRequest = new TelefoneRequest();
                    telefoneRequest.Descricao = telefone.Descricao;
                    telefoneRequest.Numero = telefone.Numero;

                    request.Telefones.Add(telefoneRequest);
                }

                listRequests.Add(request);
            }

            return listRequests.ToArray();
        }

        public Task<Fornecedor> Update(FornecedorRequest request)
        {
            throw new NotImplementedException();
        }

        private Empresa AddEmpresa(FornecedorRequest modelo)
        {
            Empresa empresa = null;

            foreach (var item in modelo.Empresas)
            {
                empresa = new Empresa();
                empresa.UF = item.UF;
                empresa.CNPJ = item.CNPJ;
                empresa.DataCadastro = DateTime.Now;
                empresa.DataAtualizacao = DateTime.Now;

                empresaPersist.UseAdd<Empresa>(empresa);
            }

            return empresa;
        }

        private void AddEmpresaFornecedor(Fornecedor fornecedor, Empresa empresa)
        {
            EmpresaFornecedor empresaFornecedor = new EmpresaFornecedor();
            empresaFornecedor.IdEmpresa = empresa.Id;
            empresaFornecedor.IdFornecedor = fornecedor.Id;
            empresaFornecedor.DataCadastro = DateTime.Now;
            empresaFornecedor.DataAtualizacao = DateTime.Now;

            empresaFornecedorPersist.UseAdd<EmpresaFornecedor>(empresaFornecedor);
        }

        private void AddTelefone(Fornecedor fornecedor, TelefoneRequest item)
        {
            Telefone telefone = new Telefone();
            telefone.IdFornecedor = fornecedor.Id;
            telefone.Descricao = item.Descricao;
            telefone.Numero = item.Numero;
            telefone.DataCadastro = DateTime.Now;
            telefone.DataAtualizacao = DateTime.Now;

            telefonePersist.UseAdd<Telefone>(telefone);
        }
    }
}