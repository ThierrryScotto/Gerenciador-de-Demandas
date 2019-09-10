using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryGerenciadorDeChamados
{
    //classe responsavel por gerenciar oo acesso ao banco de dados
    //A classe acessa e executa comando no banco de dados (SQL SERVER) diretamente
    public class AcessoAoBanco
    {
        //objeto para acesso ao banco de dados
        protected SqlConnection conexao = new SqlConnection();

        //objeto responsavel por executar o comando no banco de dados e atualizar o DataSet
        protected SqlCommand comando = new SqlCommand();

        //Construtor
        public AcessoAoBanco(string infoServer)
        {
            //recebe string de conexão
            conexao.ConnectionString = infoServer;

            //estabelecendo conexão entre o objecto de comando e o objeto de conexão
            comando.Connection = conexao;							            
        }
        //Fim construtor

        //metodo retorna uma tabela atualizada para usuário e para o técnico
        private DataTable Exibir(string comando)
        {
            //vai receber a tabela direto do banco de dados
            DataTable tabela = new DataTable();

            this.comando.CommandText = comando;
            try
            {
                conexao.Open();                                                 //abre conexão com o banco
                SqlDataReader leitura = this.comando.ExecuteReader();           //executa a pesquisa 
                tabela.Load(leitura);
            }
            catch (Exception erro)
            {
                throw erro;
            }

            finally
            {
                conexao.Close();                                                //fecha conexão com o banco
            }
            return tabela;
        }
        
    }
}
