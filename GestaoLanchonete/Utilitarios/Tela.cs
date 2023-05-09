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
          public virtual dynamic Verificar(string mensagem, TiposVerificacoes tipo)
          {
               var valor = 0;
               bool numeroInvalido = false;
               switch (tipo)
               {
                    case TiposVerificacoes.tipoString:
                         string texto;
                         do
                         {
                              Console.WriteLine(mensagem);
                              Console.Write("> ");
                              texto = Console.ReadLine();

                              if (string.IsNullOrEmpty(texto.Trim()))
                                   MensagemErro("Campo obrigatório!");


                         } while (string.IsNullOrEmpty(texto.Trim()));
                         return texto;

                    case TiposVerificacoes.tipoInt:
                         int valorint = 0;
                         do
                         {
                              numeroInvalido = false;
                              try
                              {
                                   Console.WriteLine(mensagem);
                                   Console.Write("> ");
                                   valorint = Convert.ToInt32(Console.ReadLine());
                              }
                              catch (FormatException)
                              {
                                   MensagemErro("\nCampo tem formato inválido!");
                                   numeroInvalido = true;
                              }

                         } while (numeroInvalido);
                         return valorint;

                    case TiposVerificacoes.tipoDecimal:
                         decimal valordecimal = 0;
                         do
                         {
                              numeroInvalido = false;
                              try
                              {
                                   Console.WriteLine(mensagem);
                                   Console.Write("> ");
                                   valordecimal = Convert.ToDecimal(Console.ReadLine());
                              }
                              catch (FormatException)
                              {
                                   MensagemErro("\nCampo tem formato inválido!");
                                   numeroInvalido = true;
                              }

                         } while (numeroInvalido);
                         return valordecimal;

                    case TiposVerificacoes.tipoData:
                         DateTime value;
                         value = DateTime.Now;
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

               return valor;
          }
          public enum TiposVerificacoes
          {
               tipoString, tipoInt, tipoDecimal, tipoData
          }
     }
}