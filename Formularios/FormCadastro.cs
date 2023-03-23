using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painel_de_Login.Formularios
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            MySqlManager mySqlManager = new MySqlManager(); 
            bool registrado = mySqlManager.InserirNovoUsuario(usuario, senha);
            if(registrado)
            {
                MessageBox.Show("Usuario cadastrado");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == false)
            {
                txtSenha.UseSystemPasswordChar = true;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = false;
            }
        }
    }
}
