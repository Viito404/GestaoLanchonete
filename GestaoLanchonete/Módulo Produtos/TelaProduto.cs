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
               string nomeProduto = Verificar("Entre com o nome do produto", TiposVerificacoes.tipoString);
               string marcaProduto = Verificar("\nEntre com a marca do produto", TiposVerificacoes.tipoString);
               string unidadesMedida = Verificar("\nEntre com as unidades de medidas", TiposVerificacoes.tipoString);
               decimal precoProduto = Verificar("\nEntre com o preço do produto", TiposVerificacoes.tipoDecimal);

               return new EntidadeProduto(nomeProduto, marcaProduto, unidadesMedida, precoProduto);
          }
     }
}
