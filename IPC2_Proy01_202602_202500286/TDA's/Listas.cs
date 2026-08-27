using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class Listas<T>
    {
        public Nodo<T> inicio; //nodo inicial de la lista

        public void Insertar(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>(valor);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                var actual = inicio;

                while (actual.siguiente != null)
                {
                    if (actual.siguiente.Equals(nuevo))//Reemplazo en caso de repetirse el objeto ciudad
                    {
                        actual.siguiente = nuevo;
                        return;
                    }
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevo;//Insercion de nuevo elemento
            }
        }

        public virtual void ImprimirNodo()
        {
            var actual = inicio;
            int n = 0;

            while (actual != null)
            {
                n++;
                Console.WriteLine("===Elemento No. " + n);
                Console.WriteLine(actual.valor.ToString());
                actual = actual.siguiente;
            }
        }

        public Nodo<T> Buscar(int indice)
        {
            var actual=inicio;

            for(int i =0; i<indice; i++)
            {
                actual = actual.siguiente;
            }

            return actual;
        }

        public bool Existe(T valor)
        {
            var actual = inicio;

            while (actual != null)
            {
                if(actual.valor.Equals(valor))
                {
                    return true;
                }

                actual = actual.siguiente;
            }

            return false ;
        }

        public int NoElementos()
        {
            var actual = inicio;
            int contador = 0;

            while (actual != null)
            {
                contador++;
                actual = actual.siguiente;
            }

            return contador;
        }
    }
}
