using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryGerenciadorDeChamados
{
    //Classe responsavel por fazer a verificação de login
    //caso ela retorne true sisgnifica que o usuário está  cadastrado no banco de dados

    public class VerificaLogin : AcessoAoBanco
    {
        //costrutor
        public VerificaLogin(string infoServer) : base(infoServer)
        { }

        //metodo para verificar se o usuário está no banco
        public bool VerificacaoLogin(string usuario, string senha)
        {
            //guarda a informação encontrou o usuário dentro do banco
            bool encontrado; 
            
            try
            {
                comando.CommandText = "SELECT usuario, senha FROM Login";     //comando
                conexao.Open();                                               //abrindo conexão
                SqlDataReader leitura = comando.ExecuteReader();              //retornando infirmações do banco
                encontrado = leitura.HasRows;
            }

            catch(Exception erro)
            {
                throw erro;
            }

            finally
            {
                conexao.Close();
            }
            return encontrado;
        }
    }
}
