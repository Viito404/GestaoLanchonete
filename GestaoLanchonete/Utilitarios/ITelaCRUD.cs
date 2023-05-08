using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoLanchonete.Utilitarios
{
     internal interface ITelaCRUD //Métodos Obrigatórios para as classes. Uma assinatura para as classes.
     {
          public bool OpcoesCRUD();
          public string ApresentarMenu();
          public void InserirRegistro();
          public bool VisualizarRegistros(bool mostrarMensagemNotificacao);
          public void EditarRegistros();
          public void RemoverRegistros();
     }
}
