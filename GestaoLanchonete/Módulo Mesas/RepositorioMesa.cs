namespace GestaoLanchonete.Módulo_Mesas
{
     internal class RepositorioMesa : RepositorioBase<EntidadeMesa>
     {
        public RepositorioMesa(List<EntidadeMesa> listaMesas)
        {
               this.dados = listaMesas;
        }
    }
}
