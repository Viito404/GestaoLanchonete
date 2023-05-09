using GestaoLanchonete.Módulo_Garçom;
using GestaoLanchonete.Módulo_Mesas;
using GestaoLanchonete.Módulo_Produtos;
using System.Linq;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class TelaConta : TelaBase<RepositorioConta, EntidadeConta>
     {
          private RepositorioConta repositorioConta;

          private TelaProduto telaProduto;
          private TelaGarcom telaGarcom;
          private TelaMesa telaMesa;

          public TelaConta(RepositorioConta repositorioConta, TelaProduto telaProduto, TelaGarcom telaGarcom, TelaMesa telaMesa)
          {
               this.repositorioBase = repositorioConta;
               this.repositorioConta = repositorioConta;
               this.telaProduto = telaProduto;
               this.telaGarcom = telaGarcom;
               this.telaMesa = telaMesa;

               nomeEntidade = "Conta";
               sufixo = "s";
               pronome = "a";
          }


          public override string ApresentarMenu()
          {
               Console.Clear();
               Console.WriteLine($"| {nomeEntidade}{sufixo} |");
               MensagemApresentacao("\n[1] ABRIR CONTA;\n[2] CADASTRAR PEDIDOS;\n[3] FECHAR CONTA;\n[4] VISUALIZAR CONTAS ABERTAS;\n[5] FATURAMENTO DIÁRIO\n\n[0] SAIR.");
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }

          public void AbrirNovaConta()
          {
               Console.Clear();
               MensagemNotificacao($"Abrindo {nomeEntidade}...\n");

               EntidadeConta conta = ObterRegistro();

               if (VerificarErrosValidacao(conta))
               {
                    AbrirNovaConta();
                    return;
               }

               
               repositorioBase.Inserir(conta);
               AdicionarPedidos(conta);
               conta.AbrirConta();
               MensagemSucesso("\nConta aberta com sucesso!");
          }

          public void FecharConta()
          {
               Console.Clear();
               MensagemNotificacao($"Fechando {nomeEntidade}...\n");

               bool temContasEmAberto = VisualizarContasAbertas(false);

               if (temContasEmAberto == false)
                    return;

               EntidadeConta conta = BuscarRegistro("Digite o id da Conta: ");

               conta.FecharConta();

               MensagemSucesso("\nConta fechada com sucesso!");
          }

          public void RegistrarPedidos()
          {
               Console.Clear();
               MensagemNotificacao($"Registrando pedidos...\n");

               bool temContasEmAberto = VisualizarContasAbertas(false);

               if (temContasEmAberto == false)
                    return;

               Console.WriteLine();

               EntidadeConta conta = BuscarRegistro("Digite o id da Conta: ");

               Console.Clear();
               Console.Write("[1] Adicionar Pedidos;\n[2] Remover Pedidos;\n\n[Outro] Sair.\n> ");
               string opcao = Console.ReadLine();

               if (opcao == "1")
                    AdicionarPedidos(conta);

               else if (opcao == "2")
                    RemoverPedidos(conta);
          }

          public void VisualizarFaturamentoDiario()
          {
               Console.Clear();
               MensagemNotificacao("Visualizando faturamento do dia...\n");

               DateTime data = Verificar("Entre com a data", TiposVerificacoes.tipoData);

               List<EntidadeConta> contasFechadas = repositorioConta.SelecionarContasFechadas(data);

               Faturamento faturamentoDiario = new Faturamento(contasFechadas);

               decimal totalFaturado = faturamentoDiario.CalcularTotal();

               Console.WriteLine("\nContas fechadas na data: " + data.ToShortDateString());

               MostrarTabela(contasFechadas);

               Console.WriteLine();

               MensagemSucesso("Total faturado: " + totalFaturado);
          }

          private bool VisualizarContasAbertas(bool visualizacao)
          {
               if (visualizacao)
               {
                    Console.Clear();
                    MensagemNotificacao($"Visualizando {nomeEntidade}{sufixo}...\n");
               }


               List<EntidadeConta> contasAbertas = repositorioConta.SelecionarContasAbertas();

               if (contasAbertas.Count == 0)
               {
                    MensagemAlerta("Nenhuma conta em aberto");
                    return false;
               }

               MostrarTabela(contasAbertas);

               if (visualizacao)
                    Console.ReadLine();

               return contasAbertas.Count > 0;
          }

          private void AdicionarPedidos(EntidadeConta conta)
          {
               Console.Write("\n[S] para selecionar produtos;\n[Outro] para sair.\n> ");
               string opcao = Console.ReadLine().ToUpper();

               while (opcao == "S")
               {
                    Console.Clear();
                    MensagemNotificacao($"Visualizando Produtos...\n");
                    EntidadeProduto produto = ObterProduto();

                    int quantidade = Verificar("Digite a quantidade", TiposVerificacoes.tipoInt);

                    conta.RegistrarPedidos(produto, quantidade);

                    MensagemSucesso("\nPedido realizado com sucesso!");

                    Console.Write("\nSelecionar mais produtos? [S] ou [N]:\n> ");
                    opcao = Console.ReadLine().ToUpper();
               }
          }

          private void RemoverPedidos(EntidadeConta conta)
          {
               int id = 0;

               if (conta.Pedidos.Count == 0)
               {
                    MensagemAlerta("Nenhum pedido cadastrado para esta conta!");
                    return;
               }

               conta.RemoverPedidos();
               MensagemAlerta("\nÚltimo pedido removido!");
          }

          protected override void MostrarTabela(List<EntidadeConta> registros)
          {
               foreach (EntidadeConta conta in registros)
               {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("| {0, -5} | {1, -25} | {2, -25} |", "Id", "Número Mesa", "Nome Garçom");
                    Console.ResetColor();
                    Console.WriteLine("| {0, -5} | {1, -25} | {2, -25} |", conta.id, conta.Mesa.NumeroMesa, conta.Garcom.NomeGarcom);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n| {0, -20} | {1, -10} |", "Produto", "QTD");
                    Console.ResetColor();

                    foreach (Pedidos pedido in conta.Pedidos)
                    {
                         Console.WriteLine("| {0, -20} | {1, -10} |", pedido.produto.NomeProduto, pedido.quantidadeProduto);
                    }
                    Console.WriteLine("\n\n");
               }
          }

          protected override EntidadeConta ObterRegistro()
          {
               EntidadeMesa mesa = ObterMesa();
               EntidadeGarcom garcom = ObterGarcom();
               DateTime dataAbertura = Verificar("\nEntre com a data de abertura", TiposVerificacoes.tipoData);              
               return new EntidadeConta(mesa, garcom, dataAbertura);
          }

          private EntidadeProduto ObterProduto()
          {
               telaProduto.VisualizarRegistros(false);
               EntidadeProduto produto = telaProduto.BuscarRegistro($"\nEntre com a id do produto");

               Console.WriteLine();
               return produto;
          }

          private EntidadeGarcom ObterGarcom()
          {
               telaGarcom.VisualizarRegistros(false);
               EntidadeGarcom garcom = telaGarcom.BuscarRegistro($"\nEntre com a id do garçom");

               Console.WriteLine();
               return garcom;
          }

          private EntidadeMesa ObterMesa()
          {
               telaMesa.VisualizarRegistros(false);
               EntidadeMesa mesa = telaMesa.BuscarRegistro($"\nEntre com a id da mesa");
               Console.WriteLine();               
               return mesa;
          }

          public virtual bool OpcoesCRUD()
          {
               bool continuar = true;
               do
               {
                    string opcao = ApresentarMenu();

                    switch (opcao)
                    {
                         case "1": AbrirNovaConta(); break;
                         case "2": RegistrarPedidos(); break;
                         case "3": FecharConta(); break;
                         case "4": VisualizarContasAbertas(true); break;
                         case "5": VisualizarFaturamentoDiario(); break;

                         case "0": MensagemNotificacao("\nSaindo para o menu..."); Console.ReadLine(); continuar = false; break;
                         default: MensagemErro("\nInsira um opção válida!"); break;
                    }

               } while (continuar);

               return true;
          }
     }
}
