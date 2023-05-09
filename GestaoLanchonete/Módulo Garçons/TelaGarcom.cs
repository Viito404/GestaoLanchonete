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
               Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} |", "Id", "Nome", "CPF", "Telefone");
               Console.ResetColor();

               foreach (EntidadeGarcom garcom in registros)
               {
                    Console.WriteLine("| {0, -5} | {1, -25} | {2, -20} | {3, -20} |", garcom.id, garcom.NomeGarcom, garcom.CpfGarcom, garcom.TelefoneGarcom);
               }
          }

          protected override EntidadeGarcom ObterRegistro()
          {
               string nomeGarcom = Verificar("Entre com o nome do garçom", TiposVerificacoes.tipoString);
               string cpfGarcom = Verificar("\nEntre com o CPF do garçom", TiposVerificacoes.tipoString);
               string telefoneGarcom = Verificar("\nEntre com o telefone do garçom", TiposVerificacoes.tipoString);
               return new EntidadeGarcom(nomeGarcom, cpfGarcom, telefoneGarcom);
          }
     }
}
