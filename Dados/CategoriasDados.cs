using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Cadastro_de_Categorias.Dados
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CategoriaDados
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Categorias.accdb";

        public void Inserir(string nome, string descricao)
        {
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = new OleDbCommand("INSERT INTO Categorias (Nome, Descricao) VALUES (@Nome, @Descricao)", conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Descricao", descricao);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = new OleDbCommand("SELECT Id, Nome, Descricao FROM Categorias", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : string.Empty
                        });
                    }
                }
            }
            return categorias;
        }

        public Categoria ObterPorId(int id)
        {
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = new OleDbCommand("SELECT Id, Nome, Descricao FROM Categorias WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Categoria
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : string.Empty
                        };
                    }
                }
            }
            return null;
        }

        public void Atualizar(int id, string nome, string descricao)
        {
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = new OleDbCommand("UPDATE Categorias SET Nome = @Nome, Descricao = @Descricao WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Descricao", descricao);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var cmd = new OleDbCommand("DELETE FROM Categorias WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}