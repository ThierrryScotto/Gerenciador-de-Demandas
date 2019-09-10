using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryGerenciadorDeChamados
{
    public class LoginObject
    {
        //objeto para verificar o login
        VerificaLogin login = new VerificaLogin(@"Data Source=THIERRY;Initial Catalog=Empresa;Integrated Security=True");

        //contrutor
        public LoginObject()
        { }

        //metodo para verificar se o usuário existe
        public void Logar(string usuario, string senha)
        {
            if (login.VerificacaoLogin(usuario, senha))
            {
                //cria um form de logado
            }
            else
                MessageBox.Show("Erro ao se logar");
        }
    }
}
