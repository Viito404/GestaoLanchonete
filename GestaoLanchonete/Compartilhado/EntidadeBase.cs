namespace GestaoLanchonete.Compartilhado
{
     internal abstract class EntidadeBase<TEntidade> //Passado por parâmetro o tipo da entidade.
     {
          //id universal para todos os elementos a serem cadastrados.
          public int id;


          /// <summary>
          /// Método abstrato para atualizar os registros das entidades.
          /// </summary>
          /// <param name="registroAtualizado"></param>
          public abstract void AtualizarRegistros(TEntidade registroAtualizado);

          /// <summary>
          /// Método abstrato para coletar erros específicos e regras de negócio na classe entidade do elemento desejado.
          /// </summary>
          /// <returns>ArrayList dos erros.</returns>
          public abstract ArrayList ValidarErros();
     }
}
