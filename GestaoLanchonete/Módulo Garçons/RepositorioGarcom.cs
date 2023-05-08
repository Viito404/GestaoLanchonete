using GestaoLanchonete.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
