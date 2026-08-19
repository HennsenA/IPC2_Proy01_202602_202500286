using IPC2_Proy01_202602_202500286.Modelo;
using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace IPC2_Proy01_202602_202500286.XML
{
    public class ManejoXML //Clase que maneja el archivo xml y crea los objetos Robot y Ciudad
    {
        private String ruta;
        private XDocument doc;
        
        public ManejoXML(String ruta)
        {
            this.ruta = ruta;
        }

        public bool CargaArchivo()
        {
            try
            {
                if (string.IsNullOrEmpty(ruta))
                {
                    Console.WriteLine("Error: No se especifico una ruta");
                }
                else
                {
                    doc = XDocument.Load(ruta);
                    Console.WriteLine("Archivo cargado correctamente!");
                    return true;
                }

                return false;
            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine("Error: El archivo no se encontro o no es correcta la ruta");
                return false;
            }
            catch (System.Xml.XmlException)
            {
                Console.WriteLine("Error: El documento no tiene el formato establecido o es corrupto");
                return false;
            }
        }
        public void CargarCiudades(ListaCiudades ListaCiudades)
        {
            try
            {
                var nodosCiudad = doc.Root.Element("listaCiudades").Elements("ciudad");

                if (nodosCiudad == null) { Console.WriteLine("Error: No hay elementos de ciudad en el archivo"); return; }

                foreach (XElement nodoCiudad in nodosCiudad)
                {
                    XElement nodoNombre = nodoCiudad.Element("nombre");
                    string nombreCiudad = nodoNombre.Value.Trim();
                    int filas = int.Parse(nodoNombre.Attribute("filas").Value);
                    int columnas = int.Parse(nodoNombre.Attribute("columnas").Value);

                    //Console.WriteLine("Nombre Ciudad: " + nombreCiudad + "No. Filas: " + filas + "No. Columnas: " + columnas);
                     
                    // Leer las filas de la malla en orden
                     char[][] caracteres = new char[filas][];
                     foreach (XElement nodoFila in nodoCiudad.Elements("fila"))
                     {
                         int numeroFila = int.Parse(nodoFila.Attribute("numero").Value);
                         string contenido = nodoFila.Value.Trim('"');
                         caracteres[numeroFila - 1] = contenido.ToCharArray();
                     }

                     Ciudades ciudad = new Ciudades(nombreCiudad, filas, columnas);
                     ciudad.CrearMalla(caracteres);

                     // Creacion de las Unidades de Combate
                     foreach (XElement nodoUnidadMilitar in nodoCiudad.Elements("unidadMilitar"))
                     {
                         int f = int.Parse(nodoUnidadMilitar.Attribute("fila").Value);
                         int c = int.Parse(nodoUnidadMilitar.Attribute("columna").Value);
                         int capacidad = int.Parse(nodoUnidadMilitar.Value.Trim());
                         Celda UnidadMilitar = new Celda(capacidad, f, c);
                     }

                    ListaCiudades.Insertar(ciudad);
                    Console.WriteLine("Ciudades cargadas!");
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error: No se encontro el objeto ciudad o no existe");
            }
        }
        public void CargarRobots(ListaRobots ListaRobots)
        {
            try
            {
                //String datos;
                /*datos = 
                       $"""

                       Robot
                       nombre:               {nombre}
                       tipo:                 {tipo}
                       Capacidad de combate: {capcomb}

                       """;

                   Console.WriteLine(datos);*/

                var nodoRobots = doc.Root.Element("robots").Elements("robot");
                if (nodoRobots == null)
                {
                    Console.WriteLine("Error: No se encontraron los Robots o no existen");
                    return;
                }

                foreach(XElement robots in nodoRobots)
                {
                    XElement nodoNombre = robots.Element("nombre");
                    String nombre = nodoNombre.Value;
                    String tipo = nodoNombre.Attribute("tipo").Value;
                    String capacidad; 
                    int capcomb = 0;

                    if(nodoNombre.Attribute("capacidad")!=null)
                    {
                        capacidad = nodoNombre.Attribute("capacidad").Value;
                        capcomb = int.Parse(capacidad);
                    }

                    if (tipo.Equals("ChapinRescue"))
                    {
                        ChapinRescue RescueRobot = new ChapinRescue(nombre, capcomb);
                        ListaRobots.Insertar(RescueRobot);
                    }
                    else
                    {
                        ChapinFighter FighterRobot = new ChapinFighter(nombre, capcomb);
                        ListaRobots.Insertar(FighterRobot);
                    }
                }

                Console.WriteLine("Robots cargados!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
        }
    }
}
