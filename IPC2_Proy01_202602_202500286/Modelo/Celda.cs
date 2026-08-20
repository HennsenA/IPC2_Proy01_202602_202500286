using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class Celda
    {
        private int capcomb {  get; set; }
        private char tipo { get; set; }
        private int columna {  get; set; } 
        private int fila {  get; set; }

        public Celda(char tipo, int columna, int fila)
        {
            this.capcomb = 0;
            this.columna = columna;
            this.fila = fila;
            this.tipo = tipo;
        }
        public Celda(int capcomb, int columna, int fila)
        {
            this.capcomb = capcomb;
            this.columna = columna;
            this.fila = fila;
            this.tipo = 'U';
        }

        public void SetTipo()
        {
            
        }

        public bool Transitable() { return false;  }
    }
}
