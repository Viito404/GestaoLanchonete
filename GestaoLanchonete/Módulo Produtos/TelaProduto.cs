using GestaoLanchonete.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Produtos
{
     internal class TelaProduto : TelaBase<RepositorioProduto, EntidadeProduto>
     {
          public TelaProduto(RepositorioProduto repositorioProduto)
          {
               this.repositorioBase = repositorioProduto;
               nomeEntidade = "Produto";
               sufixo = "s";
               pronome = "o";
          }

          protected override void MostrarTabela(List<EntidadeProduto> registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} | {4, -10} |", "Id", "Nome", "Marca Produto", "Unidade medida", "Preço");
               Console.ResetColor();

               foreach (EntidadeProduto produto in registros)
               {
                    Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} | {4, -10} |", produto.id, produto.NomeProduto, produto.MarcaProduto, produto.UnidadesMedida, produto.PrecoProduto.ToString("F2"));
               }
          }

          protected override EntidadeProduto ObterRegistro()
          {
               string nomeProduto = VerificarString("Entre com o nome do produto");
               string marcaProduto = VerificarString("\nEntre com a marca do produto");
               string unidadesMedida = VerificarString("\nEntre com as unidades de medidas");
               decimal precoProduto = VerificarDecimal("\nEntre com o preço do produto");

               return new EntidadeProduto(nomeProduto, marcaProduto, unidadesMedida, precoProduto);
          }
     }
}
