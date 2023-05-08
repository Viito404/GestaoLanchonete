using GestaoLanchonete.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class RepositorioConta : RepositorioBase<EntidadeConta>
     {
          public RepositorioConta(List<EntidadeConta> listaContas)
          {
               this.dados = listaContas;
          }

          public List<EntidadeConta> SelecionarContasAbertas()
          {
               List<EntidadeConta> listaContasAbertas = new List<EntidadeConta>();

               foreach(EntidadeConta conta in dados)
               {
                    if (conta.EstaAberta == true)
                         listaContasAbertas.Add(conta);
               }

               return listaContasAbertas;
          }

          public List<EntidadeConta> SelecionarContasFechadas(DateTime dataFechamento)
          {
               List<EntidadeConta> listaContasFechadas = new List<EntidadeConta>();

               foreach (EntidadeConta conta in dados)
               {
                    if (conta.EstaAberta == false && conta.DataAbertura.Date == dataFechamento.Date)
                         listaContasFechadas.Add(conta);
               }

               return listaContasFechadas;
          }
     }
}
