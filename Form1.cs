using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Painel_de_Login.Formularios;

namespace Painel_de_Login
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text;
            string senha = txtSenha.Text;
            MySqlManager mySqlManager = new MySqlManager();
            bool usuario_existe = mySqlManager.VerificarUsuario(usuario, senha);
            if (usuario_existe)
            {
                MessageBox.Show("Usuario Existe!");
            }
            else
            {
                MessageBox.Show("Usuario ou Senha INcorretos!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadastro form = new FormCadastro();
            form.Show();
        }
    }
}
