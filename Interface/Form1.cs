using System;
using System.Windows.Forms;
using Cadastro_de_Categorias.Negocio;
using Cadastro_de_Categorias.Dados;

namespace Cadastro_de_Categorias.Interface
{
    public partial class Form1 : Form
    {
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private int? categoriaSelecionadaId = null;

        public Form1()
        {
            InitializeComponent();
            AtualizarGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                categoriaNegocio.Inserir(txtNome.Text, txtDescricao.Text);
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Categoria inserida com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSelecionadaId == null)
                {
                    MessageBox.Show("Selecione uma categoria para atualizar.");
                    return;
                }
                categoriaNegocio.Atualizar(categoriaSelecionadaId.Value, txtNome.Text, txtDescricao.Text);
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSelecionadaId == null)
                {
                    MessageBox.Show("Selecione uma categoria para excluir.");
                    return;
                }
                categoriaNegocio.Excluir(categoriaSelecionadaId.Value);
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Categoria excluída com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null && dgvCategorias.CurrentRow.DataBoundItem is Categoria categoria)
            {
                categoriaSelecionadaId = categoria.Id;
                txtNome.Text = categoria.Nome;
                txtDescricao.Text = categoria.Descricao;
            }
        }

        private void AtualizarGrid()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = categoriaNegocio.Listar();
            dgvCategorias.ClearSelection();
            categoriaSelecionadaId = null;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            categoriaSelecionadaId = null;
            dgvCategorias.ClearSelection();
        }
    }
}