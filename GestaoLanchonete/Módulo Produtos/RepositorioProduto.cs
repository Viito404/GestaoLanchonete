namespace GestaoLanchonete.Módulo_Produtos
{
     internal class RepositorioProduto : RepositorioBase<EntidadeProduto>
     {
          public RepositorioProduto(List<EntidadeProduto> listaProdutos)
          {
               this.dados = listaProdutos;
          }
     }
}
