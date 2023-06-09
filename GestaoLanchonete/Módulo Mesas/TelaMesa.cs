﻿namespace GestaoLanchonete.Módulo_Mesas
{
     internal class TelaMesa : TelaBase<RepositorioMesa, EntidadeMesa>
     {
          public TelaMesa(RepositorioMesa repositorioMesa)
          {
               this.repositorioBase = repositorioMesa;
               nomeEntidade = "Mesa";
               sufixo = "s";
               pronome = "a";
          }

          protected override void MostrarTabela(List<EntidadeMesa> registros)
          {
               Console.BackgroundColor = ConsoleColor.Magenta;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -5} | {1, -10} | {2, -25} | {3, -15} |", "Id", "Número", "Localização", "Disponibilidade");
               Console.ResetColor();

               foreach (EntidadeMesa mesa in registros)
               {
                    Console.WriteLine("| {0, -5} | {1, -10} | {2, -25} | {3, -15} |", mesa.id, mesa.NumeroMesa, mesa.LocalizacaoMesa, mesa.DisponibilidadeMesa);
               }
          }

          protected override EntidadeMesa ObterRegistro()
          {
               int numeroMesa = Verificar("Entre com o número da mesa", TiposVerificacoes.tipoInt);
               string localizacaoMesa = Verificar("\nEntre com a localização da mesa", TiposVerificacoes.tipoString);
               bool disponibilidadeMesa = true;
               return new EntidadeMesa(numeroMesa, localizacaoMesa, disponibilidadeMesa);
          }
     }
}
