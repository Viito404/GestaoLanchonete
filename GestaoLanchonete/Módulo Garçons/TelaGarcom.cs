using GestaoLanchonete.Compartilhado;
using GestaoLanchonete.Módulo_Mesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Módulo_Garçom
{
     internal class TelaGarcom : TelaBase<RepositorioGarcom, EntidadeGarcom>
     {
        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
               this.repositorioBase = repositorioGarcom;
               nomeEntidade = "Garçom";
               sufixo = "";
               pronome = "o";
        }

        protected override void MostrarTabela(List<EntidadeGarcom> registros)
          {
               Console.BackgroundColor = ConsoleColor.DarkGreen;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} | ", "Id", "Nome", "CPF", "Telefone");
               Console.ResetColor();

               foreach (EntidadeGarcom garcom in registros)
               {
                    Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} |", garcom.id, garcom.NomeGarcom, garcom.CpfGarcom, garcom.TelefoneGarcom);
               }
          }

          protected override EntidadeGarcom ObterRegistro()
          {
               string nomeGarcom = VerificarString("Entre com o nome do garçom");
               string cpfGarcom = VerificarString("\nEntre com o CPF do garçom");
               string telefoneGarcom = VerificarString("\nEntre com o telefone do garçom");
               return new EntidadeGarcom(nomeGarcom, cpfGarcom, telefoneGarcom);
          }
     }
}
