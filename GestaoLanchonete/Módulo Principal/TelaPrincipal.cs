using GestaoLanchonete.Módulo_Contas;
using GestaoLanchonete.Módulo_Garçom;
using GestaoLanchonete.Módulo_Mesas;
using GestaoLanchonete.Módulo_Produtos;
using GestaoLanchonete.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete
{
     internal class TelaPrincipal : Tela
     {
          private TelaProduto telaProduto;
          private TelaGarcom telaGarcom;
          private TelaMesa telaMesa;
          private TelaConta telaConta;

          public TelaPrincipal()
          {
               RepositorioProduto repositorioProduto = new RepositorioProduto(new List<EntidadeProduto>());
               RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new List<EntidadeGarcom>());
               RepositorioMesa repositorioMesa = new RepositorioMesa(new List<EntidadeMesa>());
               RepositorioConta repositorioConta = new RepositorioConta(new List<EntidadeConta>());

               CadastrarAutomaticamente(repositorioProduto, repositorioGarcom, repositorioMesa);

               telaProduto = new TelaProduto(repositorioProduto);
               telaGarcom = new TelaGarcom(repositorioGarcom);
               telaMesa = new TelaMesa(repositorioMesa);
               telaConta = new TelaConta(repositorioConta, telaProduto, telaGarcom, telaMesa);
          }

          public string ApresentarMenu(string titulo)
          {
               Console.Clear();
               Console.WriteLine($"| {titulo} |");
               MensagemApresentacao("\n[1] PRODUTOS;\n[2] GARÇONS;\n[3] MESAS;\n[4] CONTAS\n[0] SAIR.");
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }

          public ITelaCRUD SelecionarTela()
          {
                    string opcao = ApresentarMenu("Lanchonete do Zé");

               if (opcao == "1")
                    return telaProduto;

               else if (opcao == "2")
                    return telaGarcom;

               else if (opcao == "3")
                    return telaMesa;

               else if (opcao == "4")
                    return telaconta;

               if (opcao == "0")
                         return null;

                    else
                    {
                         MensagemErro("\nInsira uma opção válida!");
                         return SelecionarTela();
                    }
          }

          private void CadastrarAutomaticamente(RepositorioProduto repositorioProduto, RepositorioGarcom repositorioGarcom, RepositorioMesa repositorioMesa)
          {
               AutoProdutos(repositorioProduto);
               AutoGarcons(repositorioGarcom);
               AutoMesas(repositorioMesa);
          }

          private static void AutoMesas(RepositorioMesa repositorioMesa)
          {
               EntidadeMesa mesa = new EntidadeMesa(1, "Entrada", true);
               EntidadeMesa mesa1 = new EntidadeMesa(2, "Entrada", true);
               EntidadeMesa mesa2 = new EntidadeMesa(3, "Janela", true);
               EntidadeMesa mesa3 = new EntidadeMesa(4, "Janela", true);
               EntidadeMesa mesa4 = new EntidadeMesa(5, "Janela", true);

               repositorioMesa.Inserir(mesa);
               repositorioMesa.Inserir(mesa1);
               repositorioMesa.Inserir(mesa2);
               repositorioMesa.Inserir(mesa3);
               repositorioMesa.Inserir(mesa4);
          }

          private static void AutoGarcons(RepositorioGarcom repositorioGarcom)
          {
               EntidadeGarcom garcom = new EntidadeGarcom("Pedro Alves", "014.021.213-12", "3224-9210");
               EntidadeGarcom garcom1 = new EntidadeGarcom("Marcelo Pereira", "032.213.523-43", "4799840936");
               EntidadeGarcom garcom2 = new EntidadeGarcom("Diogo dos Santos", "021.172.187-48", "4999123482");
               EntidadeGarcom garcom3 = new EntidadeGarcom("Rafael Talavares", "018.012.371-21", "4592305678");
               EntidadeGarcom garcom4 = new EntidadeGarcom("Stephanie de Souza Lima", "029.128.128-38", "3234-1284");

               repositorioGarcom.Inserir(garcom);
               repositorioGarcom.Inserir(garcom1);
               repositorioGarcom.Inserir(garcom2);
               repositorioGarcom.Inserir(garcom3);
               repositorioGarcom.Inserir(garcom4);
          }

          private static void AutoProdutos(RepositorioProduto repositorioProduto)
          {
               EntidadeProduto produto = new EntidadeProduto("Água", "Crystal", "500ml", (decimal)4.50);
               EntidadeProduto produto1 = new EntidadeProduto("Refrigerante Uva", "Fanta", "2L", (decimal)7.50);
               EntidadeProduto produto2 = new EntidadeProduto("Pastel", "Lanchonete do Zé", "120g", (decimal)6.50);
               EntidadeProduto produto3 = new EntidadeProduto("Coxinha", "Lanchonete do Zé", "500ml", (decimal)8.00);
               EntidadeProduto produto4 = new EntidadeProduto("Suco Abacaxi", "Lanchonete do Zé", "500ml", (decimal)6.50);

               repositorioProduto.Inserir(produto);
               repositorioProduto.Inserir(produto1);
               repositorioProduto.Inserir(produto2);
               repositorioProduto.Inserir(produto3);
               repositorioProduto.Inserir(produto4);
          }
     }
}
