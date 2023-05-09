namespace GestaoLanchonete.Compartilhado
{
     internal class RepositorioBase<TEntidade> //Passado por parâmetro o tipo da entidade.
          where TEntidade : EntidadeBase<TEntidade> //where afirma que TEntidade herda atributos e métodos de EntidadeBase.
     {
          protected List<TEntidade> dados; //Lista de objetos do tipo TEntidade.
          protected int contadorID = 0; //Contagem de id para entidades cadastradas.

          /// <summary>
          /// Utilizando a id, verifica se existe registros correspondentes.
          /// </summary>
          /// <param name="id"></param>
          /// <returns>O objeto do tipo TEntidade ou null.</returns>
          public virtual TEntidade SelecionarPorID(int id)
          {
               return dados.Find(a => a.id == id);
          }

          /// <summary>
          /// Insere um novo objeto do tipo TEntidade e aumenta o contador de id.
          /// </summary>
          /// <param name="novoRegistro"></param>
          public virtual void Inserir(TEntidade novoRegistro)
          {
               contadorID++;
               novoRegistro.id = contadorID;
               dados.Add(novoRegistro);
          }

          /// <summary>
          /// Recebe o registro antigo e o novo registro, e chama o método 'AtualizarRegistros' para efetuar a sobreescrição dos dados. 
          /// </summary>
          /// <param name="registroAntigo"></param>
          /// <param name="registroAtualizado"></param>
          public virtual void Editar(TEntidade registroAntigo, TEntidade registroAtualizado)
          {
               registroAntigo.AtualizarRegistros(registroAtualizado);
          }

          /// <summary>
          /// Recebe o registro especificado e o remove da lista 'dados'.
          /// </summary>
          /// <param name="registroSelecionado"></param>
          public virtual void Remover(TEntidade registroSelecionado)
          {
               dados.Remove(registroSelecionado);
          }

          /// <summary>
          /// Retorna registros da lista 'dados'.
          /// </summary>
          /// <returns>Uma lista do tipo TEntidade.</returns>
          public virtual List<TEntidade> SelecionarRegistros()
          {
               return dados;
          }
       
          /// <summary>
          /// Verifica se existe registros na lista 'dados'.
          /// </summary>
          /// <returns>True caso exista, e caso contrário retorna false.</returns>
          public bool ExisteRegistros()
          {
               return dados.Count > 0;
          }
     }
}
