using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    internal class Pila
    {
        private int maxsize;
        private Nodo[] nodos;
        private int tope;

        public Pila(int maxsize) { //Numero de nodos 
            this.maxsize = maxsize;
            this.nodos = new Nodo[maxsize];
            this.tope = -1;
        }

        private bool PilaLlena() {
            if (tope==maxsize-1) {
                return true;
            }

            return false;
        }

        private bool PilaVacia() {
            if (tope == -1) {
                return true;
            }
            return false;
        }

        public void Push(Nodo nodo) {
            if (PilaLlena() == true)
            {

                Console.WriteLine("Error: no se puede insertar el valor, pila llena");
                return;
            }
            else {
                tope++;
                nodos[tope] = nodo;
                Console.WriteLine("Nodo insertado!");
                return;
            }
        }

        public Nodo Pop() {
            Nodo nodo;
            if (PilaVacia() == true)
            {
                Console.WriteLine("Error: No hay elementos en la pila");
                return null;
            }
            else
            { 
                nodo = nodos[tope];
                tope--;
                return nodo;
            }
        }
    }
}
