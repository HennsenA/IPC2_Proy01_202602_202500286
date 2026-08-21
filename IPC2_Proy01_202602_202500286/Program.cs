using IPC2_Proy01_202602_202500286.Modelo;
using IPC2_Proy01_202602_202500286.TDA_s;
using IPC2_Proy01_202602_202500286.XML;
using System.Runtime.InteropServices.Marshalling;

namespace IPC2_Proy01_202602_202500286;

public class Sistema {
    public ListaRobots ListaRobots;
    public ListaCiudades ListaCiudades;

    public Sistema()
    {
        ListaRobots= new ListaRobots();
        ListaCiudades= new ListaCiudades();
    }

    public static void Main(string[] args)
    {
        Sistema metodos = new Sistema();

        int option = 1;
        while (option > 0) {
            mostrarMenu();
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    metodos.cargarArchivos();
                break;
                
            }
        }
    }

    public static void mostrarMenu() {
        String menu =
            """
            =================================================
            |           Chapin Wariors System               |
            =================================================
            |   0. Salir                                    |
            |   1. Cargar archivos de configuracion         |
            |   2. Ejecutar Misiones                        |
            =================================================
            |Selecciona una opcion:
            """;

        Console.WriteLine(menu);
    }

    public void cargarArchivos()
    {
        String ruta = "";
        Console.WriteLine("Ingrese la ruta del archivo: ");

        while (ruta=="" || ruta==null)
        {
            ruta = Console.ReadLine();
            if (ruta == "" || ruta == null)
            {
                Console.WriteLine("Error: ruta vacia, ingrese de nuevo");
            }
        }

        ManejoXML UsoXml = new ManejoXML(ruta);
        bool estado = UsoXml.CargaArchivo();
        if (estado == false)
        {
            Console.WriteLine("Error: No se cargo el archivo");
            return;
        }

        UsoXml.CargarRobots(ListaRobots);
        UsoXml.CargarCiudades(ListaCiudades);
    }
    public void ejecutarMisiones() { }
    public void MisionRescate() { }
    public void MisionExtraccion() { }
}