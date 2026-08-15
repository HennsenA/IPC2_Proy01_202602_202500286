using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class Ciudades
    {
        private String nombre { get; set; }
        private int filas {  get; set; } //iteraciones para crear filas
        private int columnas { get; set; } //iteraciones para crear celdas 
        private NodoCeldas ListaFilas; //Puntero para saber la lista de esta ciudad

        public Ciudades(String nombre, int filas, int columnas, NodoCeldas ListaFilas)
        {
            this.nombre = nombre;
            this.filas = filas;
            this.columnas = columnas;
            this.ListaFilas = ListaFilas;
        }

        public void CrearMalla()
        {

        }
        public void VerMalla()
        {

        }
        public bool PoseeCiviles() {
            return false;
        }

        public bool PoseeRecursos()
        {
            return false;
        }
    }
}
