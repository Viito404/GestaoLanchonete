namespace GestaoLanchonete.Módulo_Produtos
{
     internal class EntidadeProduto : EntidadeBase<EntidadeProduto>
     {
          private string nomeProduto;
          private string marcaProduto;
          private string unidadesMedida;
          private decimal precoProduto;

          public EntidadeProduto(string nomeProduto, string marcaProduto, string unidadesMedida, decimal precoProduto)
          {
               this.NomeProduto = nomeProduto;
               this.MarcaProduto = marcaProduto;
               this.UnidadesMedida = unidadesMedida;
               this.PrecoProduto = precoProduto;
          }

          public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
          public string MarcaProduto { get => marcaProduto; set => marcaProduto = value; }
          public string UnidadesMedida { get => unidadesMedida; set => unidadesMedida = value; }
          public decimal PrecoProduto { get => precoProduto; set => precoProduto = value; }
          public override void AtualizarRegistros(EntidadeProduto produtoAtualizado)
          {
               nomeProduto = produtoAtualizado.nomeProduto;
               unidadesMedida = produtoAtualizado.unidadesMedida;
               precoProduto = produtoAtualizado.precoProduto;
          }
         
          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();

               if (nomeProduto.Length < 3)
                    listaErros.Add("Campo \"nomeProduto\" deve conter mais de duas letras!");

               if (marcaProduto.Length == 1)
                    listaErros.Add("Campo \"marcaProduto\" deve conter mais de uma letra!");

               if (precoProduto == 0)
                    listaErros.Add("Campo \"precoProduto\" deve conter um valor!");

               return listaErros;
          }
     }
}
