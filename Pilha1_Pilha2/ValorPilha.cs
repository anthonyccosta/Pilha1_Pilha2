using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilha1_Pilha2
{
    internal class ValorPilha
    {
        Numero topo;

        public ValorPilha()
        {
            topo = null;
        }
        public void push(Numero aux)
        {
            if (IsEmpty() == true)
            {
                topo = aux;
            }
            else
            {
                aux.setAnterior(topo);
                topo = aux;
            }
        }
        public int pop()
        {
            int valor = 0;
            if (!IsEmpty())
            {
                valor = topo.getNumero();
                topo = topo.getAnterior();
            }
            return valor;
        }
        public int getContador()
        {
            int contador = 0;
            Numero aux = topo;
            if (!IsEmpty())
            {
                do
                {
                    contador++;
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            return contador;
        }
        bool IsEmpty()
        {
            if (topo == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string print(int tipo)
        {
            Numero aux = topo;
            string texto = "";
                if (!IsEmpty())
            {
                switch (tipo)
                {
                    case 0: // pares
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 == 0)
                                {
                                    texto += $"{aux.ToString()}";
                                }
                            }
                        } while (aux != null);
                        break;
                    case 1: // impar
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 != 0)
                                {
                                    texto += $"{aux.ToString()} ";
                                }
                            }
                            aux = aux.getAnterior();
                        } while (aux != null);
                        break;
                    default: // todos os numeros
                        do
                        {
                            texto += $"{aux.ToString()} ";
                            aux = aux.getAnterior();
                        } while (aux != null);
                        break;
                }
            }
            return texto;
        }
        public float getValor(int tamanho)
        {
            Numero aux = topo;
            float valor = 0, contador = 0;
            float resultado = 0;
            if (!IsEmpty())
            {
                switch (tamanho)
                {
                    case 0: //  menor valor
                        valor = resultado = aux.getNumero();
                        do
                        {
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor < resultado)
                            {
                                resultado = valor;
                            }
                        } while (aux != null);
                        break;
                    case 1: //  maior valor
                        valor = resultado = aux.getNumero();
                        do
                        {
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor > resultado)
                            {
                                resultado = valor;
                            }
                        } while (aux != null);
                        break;
                    default:
                        valor = aux.getNumero();
                        do
                        {
                            contador++;
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor += aux.getNumero();
                            }
                        } while (aux != null);
                        if (contador > 0)
                        {
                            resultado = (valor / contador);
                        }
                        break;
                }
            }
            return resultado;
        }
    }
}
