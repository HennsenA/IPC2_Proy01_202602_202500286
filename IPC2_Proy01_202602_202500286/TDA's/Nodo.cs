using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class Nodo<T>
    {
        public T valor;
        public Nodo<T> siguiente;
        public Nodo<T> anterior;

        public Nodo(T valor)
        {
            this.valor = valor;
            this.siguiente = null;
            this.anterior = null;
        }
    }
}
