using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel_de_Login
{
    public class MySqlManager
    {
        private string data_source = "datasource=localhost;username=root;password=;database=usuarios";
        //Construtor
        public MySqlManager() { }

        public bool VerificarUsuario(string usuario, string senha)
        {
            try
            {
                //utilizar o metodo using para garantir que seja fechado corretamente a conexao
                using (MySqlConnection connection = new MySqlConnection(this.data_source))
                {
                    connection.Open();
                    //Comando para buscar um username e senha iguais no banco de dados
                    string query = "SELECT Username, senha FROM login WHERE Username = @usuario AND senha = @senha";
                    using (MySqlCommand selectCommand = new MySqlCommand(query, connection))
                    {
                        //Adicionando Parametros
                        selectCommand.Parameters.AddWithValue("@usuario", usuario);
                        selectCommand.Parameters.AddWithValue("@senha", senha);
                        //
                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            //verifica se o comando teve pelo menos uma linha de retorno
                            if (reader.HasRows)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }

        public bool InserirNovoUsuario(string nomeDeUsuario, string senha)
        {
            //Nosso comando sql
            string inserir_usuario = "INSERT INTO login (Username, senha) VALUE (@usuario, @senha)";
            //utilizar o metodo using para garantir que seja fechado corretamente a conexao
            using (var conexao = new MySqlConnection(this.data_source))
            {
                try
                {
                    conexao.Open();
                    using (var comando = new MySqlCommand(inserir_usuario, conexao))
                    {
                        //Adicionar valores aos parametros 
                        comando.Parameters.AddWithValue("@usuario", nomeDeUsuario);
                        comando.Parameters.AddWithValue("@senha", senha);
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Erro ao inserir novo usuário", ex);
                }
            }
        }

    }
}
