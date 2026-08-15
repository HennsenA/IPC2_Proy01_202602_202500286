using IPC2_Proy01_202602_202500286.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class NodoCeldas
    {
        public Celda celda { get;}
        private NodoCeldas arriba, abajo;
        public NodoCeldas izquierda, derecha;

        public NodoCeldas(Celda celda)
        {
            this.celda = celda;
            this.arriba = null;
            this.abajo = null;
            this.izquierda = null; 
            this.derecha = null; 
        }
    }
}
