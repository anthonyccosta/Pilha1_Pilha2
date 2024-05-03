using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilha1_Pilha2
{
    internal class Numero
    {
        int valor;
        Numero anterior;
        public Numero(int numero)
        {
            this.valor = numero;
        }
        public void setAnterior(Numero num)
        {
            this.anterior = num;
        }
        public Numero getAnterior()
        {
            return this.anterior;
        }
        public int getNumero()
        {
            return this.valor;
        }

        public override string? ToString()
        {
            return "" + valor;
        }
    }
}
