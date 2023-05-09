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
              return contasFechadas.Sum(c => c.CalcularValorTotal());
          }
     }
}
