using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class Faturamento
     {
          private List<EntidadeConta> contasFechadas;

          public Faturamento(List<EntidadeConta> contasFechadas)
          {
               this.contasFechadas = contasFechadas;
          }

          public decimal CalcularTotal()
          {
               decimal total = 0;

               foreach(EntidadeConta conta in contasFechadas)
               {
                    total += conta.CalcularValorTotal();
               }

               return total;
          }
     }
}
