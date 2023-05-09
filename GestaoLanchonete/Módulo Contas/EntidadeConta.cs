using GestaoLanchonete.Módulo_Garçom;
using GestaoLanchonete.Módulo_Mesas;
using GestaoLanchonete.Módulo_Produtos;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class EntidadeConta : EntidadeBase<EntidadeConta>
     {
          private EntidadeMesa mesa;
          private List<Pedidos> pedidos;
          private EntidadeGarcom garcom;
          private bool estaAberta;
          private DateTime dataAbertura;

          public EntidadeConta(EntidadeMesa mesa, EntidadeGarcom garcom, DateTime dataAbertura)
          {
               this.mesa = mesa;
               this.garcom = garcom;
               this.dataAbertura = dataAbertura;

               pedidos = new List<Pedidos>();
               
          }

          public void AbrirConta()
          {
               estaAberta = true;
               mesa.OcuparMesa();
          }

          public void FecharConta()
          {
               estaAberta = false;
               mesa.DesocuparMesa();
          }

          public void RegistrarPedidos(EntidadeProduto produto, int quantidadeSolicitada)
          {
               Pedidos pedido = new Pedidos(produto, quantidadeSolicitada);
               pedidos.Add(pedido);
          }

          public void RemoverPedidos()
          {
               pedidos.RemoveAt(pedidos.Count - 1);
          }

          public decimal CalcularValorTotal()
          {
               return pedidos.Sum(p => p.CalcularTotalParcial());
          }

          public List<Pedidos> Pedidos { get => pedidos; set => pedidos = value; }
          public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
          internal EntidadeMesa Mesa { get => mesa; set => mesa = value; }
          internal EntidadeGarcom Garcom { get => garcom; set => garcom = value; }
          public bool EstaAberta { get => estaAberta; set => estaAberta = value; }

          public override void AtualizarRegistros(EntidadeConta contaAtualizada)
          {
               garcom = contaAtualizada.Garcom;
               mesa = contaAtualizada.Mesa;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();

               if (garcom == null)
                    listaErros.Add("\nO campo \"garcom\" é obrigatório!");


               if (mesa == null)
                    listaErros.Add("\nO campo \"mesa\" é obrigatório!");

               if (mesa.DisponibilidadeMesa == false)
                    listaErros.Add("\nA mesa já está ocupada!");

               return listaErros;
          }
     }
}
