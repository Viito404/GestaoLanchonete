namespace GestaoLanchonete.Módulo_Mesas
{
     internal class EntidadeMesa : EntidadeBase<EntidadeMesa>
     {
          private int numeroMesa;
          private string localizacaoMesa;
          private bool disponibilidadeMesa;

          public EntidadeMesa(int numeroMesa, string localizacaoMesa, bool disponibilidadeMesa)
          {
               this.numeroMesa = numeroMesa;
               this.localizacaoMesa = localizacaoMesa;
               this.disponibilidadeMesa = disponibilidadeMesa;
          }

          public int NumeroMesa { get => numeroMesa; set => numeroMesa = value; }
          public string LocalizacaoMesa { get => localizacaoMesa; set => localizacaoMesa = value; }
          public bool DisponibilidadeMesa { get => disponibilidadeMesa; set => disponibilidadeMesa = value; }

          public void OcuparMesa()
          {
               disponibilidadeMesa = false;
          }

          public void DesocuparMesa()
          {
               disponibilidadeMesa = true;
          }

          public override void AtualizarRegistros(EntidadeMesa mesaAtualizada)
          {
               numeroMesa = mesaAtualizada.numeroMesa;
               localizacaoMesa = mesaAtualizada.localizacaoMesa;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();

               if (DisponibilidadeMesa == false)
                    listaErros.Add("\nMesa não pode ser modificada pois está ocupada!");

               return listaErros;
          }
     }
}
