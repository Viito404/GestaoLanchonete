using GestaoLanchonete.Módulo_Produtos;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class Pedidos
     {
          public static int contadorId;
          public int id;

          public EntidadeProduto produto;
          public int quantidadeProduto;

          public Pedidos(EntidadeProduto produto, int quantidadeProduto)
          {
               contadorId++;
               id = contadorId;
               this.produto = produto;
               this.quantidadeProduto = quantidadeProduto;
          }

          public decimal CalcularTotalParcial()
          {
               return produto.PrecoProduto * quantidadeProduto;
          }
     }
}
