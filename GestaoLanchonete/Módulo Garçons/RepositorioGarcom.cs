namespace GestaoLanchonete.Módulo_Garçom
{
     internal class RepositorioGarcom : RepositorioBase<EntidadeGarcom>
     {
        public RepositorioGarcom(List<EntidadeGarcom> listaGarcons)
        {
               this.dados = listaGarcons;
        }
    }
}
