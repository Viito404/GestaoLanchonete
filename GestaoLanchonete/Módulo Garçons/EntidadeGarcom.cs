using GestaoLanchonete.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Garçom
{
     internal class EntidadeGarcom : EntidadeBase<EntidadeGarcom>
     {
          private string nomeGarcom, cpfGarcom, telefoneGarcom;

          public EntidadeGarcom(string nomeGarcom, string cpfGarcom, string telefoneGarcom)
          {
               this.nomeGarcom = nomeGarcom;
               this.cpfGarcom = cpfGarcom;
               this.telefoneGarcom = telefoneGarcom;
          }

          public string NomeGarcom { get => nomeGarcom; set => nomeGarcom = value; }
          public string CpfGarcom { get => cpfGarcom; set => cpfGarcom = value; }
          public string TelefoneGarcom { get => telefoneGarcom; set => telefoneGarcom = value; }

          public override void AtualizarRegistros(EntidadeGarcom garcomAtualizado)
          {
               nomeGarcom = garcomAtualizado.nomeGarcom;
               cpfGarcom = garcomAtualizado.cpfGarcom;
               telefoneGarcom = garcomAtualizado.telefoneGarcom;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();
               return listaErros;
          }
     }
}
