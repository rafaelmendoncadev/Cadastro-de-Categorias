using System;
using System.Collections.Generic;
using Cadastro_de_Categorias.Dados;

namespace Cadastro_de_Categorias.Negocio
{
    public class CategoriaNegocio
    {
        private CategoriaDados categoriaDados = new CategoriaDados();

        public void Inserir(string nome, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da categoria é obrigatório.");

            categoriaDados.Inserir(nome, descricao ?? string.Empty);
        }

        public List<Categoria> Listar()
        {
            return categoriaDados.Listar();
        }

        public Categoria ObterPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido.");

            return categoriaDados.ObterPorId(id);
        }

        public void Atualizar(int id, string nome, string descricao)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido.");
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da categoria é obrigatório.");

            categoriaDados.Atualizar(id, nome, descricao ?? string.Empty);
        }

        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido.");

            categoriaDados.Excluir(id);
        }
    }
}