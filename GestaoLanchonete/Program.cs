using GestaoLanchonete.Módulo_Contas;
using GestaoLanchonete.Utilitarios;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace GestaoLanchonete
{
     internal class Program
     {
          static void Main(string[] args)
          {
               TelaPrincipal principal = new TelaPrincipal();

               do
               {
                    ITelaCRUD tela = principal.SelecionarTela();

                    if (tela == null)
                    {
                         Console.WriteLine("\nSaindo do programa...");
                         break;
                    }

                    else if (tela is TelaConta)
                    {
                         TelaConta telaConta = (TelaConta)tela;
                         telaConta.OpcoesCRUD();
                    }

                    else
                         tela.OpcoesCRUD();

               } while (true);
          }
     }
}
