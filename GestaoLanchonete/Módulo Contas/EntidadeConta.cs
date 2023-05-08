using GestaoLanchonete.Compartilhado;
using GestaoLanchonete.Módulo_Garçom;
using GestaoLanchonete.Módulo_Mesas;
using GestaoLanchonete.Módulo_Produtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Contas
{
     internal class EntidadeConta : EntidadeBase<EntidadeConta>
     {
          private EntidadeMesa mesa;
          private ArrayList pedidos;
          private EntidadeGarcom garcom;
          private bool estaAberta;
          private DateTime dataAbertura;

          public EntidadeConta(EntidadeMesa mesa, EntidadeGarcom garcom, DateTime dataAbertura)
          {
               this.mesa = mesa;
               this.garcom = garcom;
               this.dataAbertura = dataAbertura;

               pedidos = new ArrayList();
               AbrirConta();
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

          public decimal CalcularValorTotal()
          {
               decimal total = 0;

               foreach (Pedidos pedido in pedidos)
               {
                    decimal totalPedido = pedido.CalcularTotalParcial();
                    total += totalPedido;
               }
               return total;
          }

          public ArrayList Pedidos { get => pedidos; set => pedidos = value; }
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

               return listaErros;
          }
     }
}
