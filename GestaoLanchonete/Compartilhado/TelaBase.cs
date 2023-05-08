using GestaoLanchonete.Utilitarios;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Compartilhado
{
     internal abstract class TelaBase<TRepositorio, TEntidade> : Tela, ITelaCRUD //TelaBase herda de Tela, e da interface ITelaCRUD. 
          where TRepositorio : RepositorioBase<TEntidade> //where afirma que TRepositorio poderá herdar atributos e métodos de RepositorioBase.
          where TEntidade : EntidadeBase<TEntidade> //where afirma que TEntidade poderá herdar atributos e métodos de EntidadeBase.
     {
          protected TRepositorio repositorioBase = null;

          public string nomeEntidade, sufixo, pronome;

          public virtual string ApresentarMenu()
          {
               Console.Clear();
               Console.WriteLine($"| {nomeEntidade}{sufixo} |");
               MensagemApresentacao("\n[1] CRIAR;\n[2] VISUALIZAR;\n[3] ATUALIZAR;\n[4] REMOVER;\n\n[0] SAIR.");
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }
          public virtual void InserirRegistro()
          {
               Console.Clear();
               MensagemNotificacao($"Inserindo {nomeEntidade}...\n");

               TEntidade registro = ObterRegistro();

               if (VerificarErrosValidacao(registro))
               {
                    InserirRegistro();
                    return;
               }

               repositorioBase.Inserir(registro);
               MensagemSucesso($"\n{nomeEntidade} inserid{pronome} com sucesso!");
          }
          public bool VisualizarRegistros(bool mostrarMensagemNotificacao)
          {
               if (mostrarMensagemNotificacao)
               {
                    Console.Clear();
                    MensagemNotificacao($"Visualizando {nomeEntidade}{sufixo}...\n");
               }

               List<TEntidade> registros = repositorioBase.SelecionarRegistros();

               if (registros.Count == 0)
               {
                    MensagemAlerta("Nenhum registro cadastrado!");
                    return false;
               }

               registros.Sort((x,y) => y.id.CompareTo(x.id));

               MostrarTabela(registros);

               if (mostrarMensagemNotificacao)
                    Console.ReadLine();

               return true;
          }
          public virtual void EditarRegistros()
          {
               Console.Clear();
               MensagemNotificacao($"Editando {nomeEntidade}{sufixo}...\n");

               bool temRegistro = VisualizarRegistros(false);

               if (!temRegistro)
                    return;

               Console.WriteLine();
               TEntidade registroAntigo = BuscarRegistro($"Entre com a Id d{pronome} {nomeEntidade}\n> ");
               Console.WriteLine();

               TEntidade registroAtualizado = ObterRegistro();

               if (VerificarErrosValidacao(registroAtualizado))
               {
                    EditarRegistros();
                    return;
               }

               repositorioBase.Editar(registroAntigo, registroAtualizado);
               MensagemSucesso($"\n{nomeEntidade} atualizad{pronome} com sucesso!");
          }
          public virtual void RemoverRegistros()
          {
               Console.Clear();
               MensagemNotificacao($"Removendo {nomeEntidade}{sufixo}...\n");

               bool temRegistro = VisualizarRegistros(false);

               if (!temRegistro)
                    return;

               Console.WriteLine();

               TEntidade registroSelecionado = BuscarRegistro($"Entre com a Id d{pronome} {nomeEntidade}\n> ");
               repositorioBase.Remover(registroSelecionado);

               MensagemSucesso($"\n{nomeEntidade} removid{pronome} com sucesso!");
          }

          /// <summary>
          /// Abstrato responsável por imprimir uma tabela com os registros do tipo correspondente de TEntidade.
          /// </summary>
          /// <param name="registros"></param>
          protected abstract void MostrarTabela(List<TEntidade> registros);

          /// <summary>
          /// Abstrato responsável por coletar dados e retornar um objeto do tipo correspondente de TEntidade. 
          /// </summary>
          /// <returns>Um objeto do tipo TEntidade.</returns>
          protected abstract TEntidade ObterRegistro();

          /// <summary>
          /// Verifica uma lista de erros, imprimindo possíveis erros e podendo retornar true ou false, caso exista algum tipo de erro ou não.
          /// </summary>
          /// <param name="registro"></param>
          /// <returns></returns>
          protected bool VerificarErrosValidacao(TEntidade registro)
          {
               bool existeErros = false;
               ArrayList listaErros = registro.ValidarErros();

               if (listaErros.Count > 0)
               {
                    existeErros = true;
                    Console.ForegroundColor = ConsoleColor.Red;

                    foreach (string erro in listaErros)
                    {
                         Console.WriteLine("\n" + erro);
                    }

                    Console.ResetColor();

                    Console.ReadLine();
               }

               return existeErros;
          }

          /// <summary>
          /// Verifica pela id se um registro é existente, caso exista, retorna o mesmo, caso contrário, imprime uma mensagem de erro.
          /// </summary>
          /// <param name="texto"></param>
          /// <returns>Registro do tipo TEntidade</returns>
          public virtual TEntidade BuscarRegistro(string texto)
          {
               bool idInvalido;
               TEntidade registroSelecionado = null;

               do
               {
                    idInvalido = false;
                    Console.WriteLine(texto);

                    try
                    {
                         Console.Write("> ");
                         int id = Convert.ToInt32(Console.ReadLine());
                         registroSelecionado = repositorioBase.SelecionarPorID(id);

                         if (registroSelecionado == null)
                         {
                              MensagemErro("\nEntre com uma id existente!");
                              idInvalido = true;
                         }

                    }
                    catch (FormatException)
                    {
                         MensagemErro("\nEntre com a id no formato correto!");
                         idInvalido = true;
                    }

               } while (idInvalido);

               return registroSelecionado;
          }

          public virtual bool OpcoesCRUD()
          {
               bool continuar = true;
               do
               {
                    string opcao = ApresentarMenu();

                    switch (opcao)
                    {
                         case "1": InserirRegistro(); break;
                         case "2": VisualizarRegistros(true); break;
                         case "3": EditarRegistros(); break;
                         case "4": RemoverRegistros(); break;

                         case "0": MensagemNotificacao("\nSaindo para o menu..."); Console.ReadLine(); continuar = false; break;
                         default: MensagemErro("\nInsira um opção válida!"); break;
                    }

               } while (continuar);

               return true;
          }
     }
}
