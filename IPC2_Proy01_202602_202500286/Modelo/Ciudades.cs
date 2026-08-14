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
        private Listas ListaFilas; //Puntero para saber la lista de esta ciudad

        public Ciudades(String nombre, int filas, int columnas)
        {
            this.nombre = nombre;
            this.filas = filas;
            this.columnas = columnas;
        }
    }
}
