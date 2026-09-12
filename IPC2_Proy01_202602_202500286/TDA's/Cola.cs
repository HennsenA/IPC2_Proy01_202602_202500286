using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class Cola<T>
    {
        private Nodo<T> frente;
        private Nodo<T> fin;
        private int contador;
        private int maxSize;

        public Cola(int maxSize)
        {
            frente = null;
            fin = null;
            contador = 0;
            this.maxSize = maxSize;
        }

        public void Encolar(T dato)
        {
            if (contador >= maxSize)
            {
                Console.WriteLine("La cola está llena, no se puede agregar más elementos");
                return;
            }

            Nodo<T> nuevo = new Nodo<T>(dato);

            if (fin == null)
            {
                frente = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.siguiente = nuevo;
                fin = nuevo;
            }

            contador++;
        }

        public T Desencolar()
        {
            if (ColaVacia())
            {
                Console.WriteLine("La cola está vacía, no se puede desencolar");
                return default(T);
            }

            T dato = frente.valor;
            frente = frente.siguiente;

            if (frente == null)
                fin = null;

            contador--;
            return dato;
        }

        public bool ColaVacia()
        {
            return frente == null;
        }

        public int NoElementos()
        {
            return contador;
        }

        public void VaciarCola()
        {
            frente = null;
            fin = null;
            contador = 0;
        }
    }
}
