using GestaoLanchonete.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
