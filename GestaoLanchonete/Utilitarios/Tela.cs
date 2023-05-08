using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Utilitarios
{
     internal class Tela
     {
          /// <summary>
          /// Imprime uma mensagem com cor na tela, pode ser pausada ou não dependendo do tipo.
          /// </summary>
          /// <param name="mensagem"></param>
          /// <param name="cor"></param>
          /// <param name="pausa"></param>
          private void ImprimirMensagem(string mensagem, TipoMensagem tipo)
          {
               ConsoleColor cor;
               bool pausa;

               switch (tipo)
               {
                    case TipoMensagem.Erro:
                         cor = ConsoleColor.Red; pausa = true; break;

                    case TipoMensagem.Sucesso:
                         cor = ConsoleColor.Green; pausa = true; break;

                    case TipoMensagem.Alerta:
                         cor = ConsoleColor.DarkYellow; pausa = true; break;

                    case TipoMensagem.Notificacao:
                         cor = ConsoleColor.DarkGray; pausa = false; break;

                    case TipoMensagem.Apresentacao:
                         cor = ConsoleColor.DarkBlue; pausa = false; break;

                    default:
                         cor = ConsoleColor.White; pausa = false; break;
               }

               Console.ForegroundColor = cor;
               Console.WriteLine(mensagem);
               Console.ResetColor();

               if (pausa)
                    Console.ReadLine();
          }

          /// <summary>
          /// Imprime uma mensagem de erro, com a cor vermelha e com uma pausa.
          /// </summary>
          /// <param name="mensagem"></param>
          protected void MensagemErro(string mensagem)
          {
               ImprimirMensagem(mensagem, TipoMensagem.Erro);
          }

          /// <summary>
          /// Imprime uma mensagem de sucesso, com a cor verde e com uma pausa.
          /// </summary>
          /// <param name="mensagem"></param>
          protected void MensagemSucesso(string mensagem)
          {
               ImprimirMensagem(mensagem, TipoMensagem.Sucesso);
          }

          /// <summary>
          /// Imprime uma mensagem de alerta, com a cor amarela e com uma pausa.
          /// </summary>
          /// <param name="mensagem"></param>
          protected void MensagemAlerta(string mensagem)
          {
               ImprimirMensagem(mensagem, TipoMensagem.Alerta);
          }

          /// <summary>
          /// Imprime uma mensagem de notificação, com a cor cinza escuro e sem pausa.
          /// </summary>
          /// <param name="mensagem"></param>
          protected void MensagemNotificacao(string mensagem)
          {
               ImprimirMensagem(mensagem, TipoMensagem.Notificacao);
          }

          /// <summary>
          /// Imprime uma mensagem de apresentação, com a cor azul escuro e sem pausa.
          /// </summary>
          /// <param name="mensagem"></param>
          protected void MensagemApresentacao(string mensagem)
          {
               ImprimirMensagem(mensagem, TipoMensagem.Apresentacao);
          }

          /// <summary>
          /// Define os tipos de mensagens que podem ser utilizadas.
          /// </summary>
          public enum TipoMensagem
          {
               Erro, Sucesso, Alerta, Notificacao, Apresentacao
          }

          public virtual string VerificarString(string mensagem)
          {
               string value = null;

               do
               {
                    Console.WriteLine(mensagem);
                    Console.Write("> ");
                    value = Console.ReadLine();

                    if (string.IsNullOrEmpty(value.Trim()))
                         MensagemErro("Campo obrigatório!");
                    

               } while (string.IsNullOrEmpty(value.Trim()));

               return value;
          }

          public virtual decimal VerificarDecimal(string mensagem)
          {
               decimal value = 0;
               bool numeroInvalido = false;

               do
               {
                    numeroInvalido = false;
                    try
                    {
                         Console.WriteLine(mensagem);
                         Console.Write("> ");
                         value = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                         MensagemErro("\nCampo tem formato inválido!");
                         numeroInvalido = true;
                    }

               } while (numeroInvalido);

               return value;
          }

          public virtual int VerificarInt(string mensagem)
          {
               int value = 0;
               bool numeroInvalido = false;

               do
               {
                    numeroInvalido = false;
                    try
                    {
                         Console.WriteLine(mensagem);
                         Console.Write("> ");
                         value = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                         MensagemErro("\nCampo tem formato inválido!");
                         numeroInvalido = true;
                    }

               } while (numeroInvalido);

               return value;
          }

          public virtual DateTime VerificarData(string mensagem)
          {
               DateTime value;
               value = DateTime.Now;
               bool numeroInvalido = false;

               do
               {
                    numeroInvalido = false;
                    try
                    {
                         Console.WriteLine(mensagem);
                         Console.Write("> ");
                         value = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                         MensagemErro("\nCampo tem formato inválido!");
                         numeroInvalido = true;
                    }

               } while (numeroInvalido);

               return value;
          }
     }
}