using GestaoLanchonete.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
