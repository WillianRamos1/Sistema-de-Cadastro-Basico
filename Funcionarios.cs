using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;


namespace CRUD
{
    public partial class Funcionarios : Form
    {
        public Funcionarios()
        {
            InitializeComponent();
           
            txtPesquisa.Enabled = true;
            txtNome.Enabled = false;
            mskTelefone.Enabled = false;
            mskCelular.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtRG.Enabled = false;
            txtCPF.Enabled = false;
            btn_Salvar.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Excluir.Enabled = false;
        }


        SqlConnection connection = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Willian;Data Source=DESKTOP-79R9K1O\SQLEXPRESS";
        private string strSql = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            strSql = "select * from Funcionarios where Nome=@Pesquisa";

            connection = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, connection);

            comando.Parameters.Add("@Pesquisa", SqlDbType.VarChar).Value = txtPesquisa.Text;

            try
            {
                if (txtPesquisa.Text == string.Empty)
                {
                    MessageBox.Show("Voce precisa digitar um nome");
                }

                connection.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("Esse nome não esta cadastrado");
                }

                dr.Read();

                txtNome.Text = Convert.ToString(dr["Nome"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);
                mskCelular.Text = Convert.ToString(dr["Celular"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                txtNumero.Text = Convert.ToString(dr["Numero"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtRG.Text = Convert.ToString(dr["RG"]);
                txtCPF.Text = Convert.ToString(dr["CPF"]);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally {

                connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Funcionarios_Load(object sender, EventArgs e)
        {

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into Funcionarios(Nome, Telefone, Celular, Email, Endereco, Numero, Bairro, RG, CPF)values(@Nome, @Telefone, @Celular, @Email, @Endereco, @Numero, @Bairro, @RG, @CPF)";

            connection = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, connection);


            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txtRG.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txtCPF.Text;

            try
            {
                connection.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro efetuado com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }


        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            strSql = "update Funcionarios set Nome=@Nome, Telefone=@Telefone, Celular=@Celular, Email=@Email, Endereco=@Endereco, Numero=@Numero, Bairro=@Bairro, RG=@RG, CPF=@CPF";

            connection = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, connection);


            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = mskCelular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txtRG.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txtCPF.Text;


            try
            {

                connection.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro atualizado com sucesso");
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);

            }

            finally
            {

                connection.Close();
            }

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            strSql = "delete from Funcionarios where Nome=@Nome";

            connection = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, connection);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;

            try
            {
                connection.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro excluido com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            txtPesquisa.Enabled = true;
            txtNome.Enabled = true;
            mskTelefone.Enabled = true;
            mskCelular.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtRG.Enabled = true;
            txtCPF.Enabled = true;
            btn_Salvar.Enabled = true;
            btn_Editar.Enabled = true;
            btn_Excluir.Enabled = true;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtRG_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
