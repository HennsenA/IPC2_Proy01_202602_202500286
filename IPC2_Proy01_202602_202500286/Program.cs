using IPC2_Proy01_202602_202500286.XML;

namespace IPC2_Proy01_202602_202500286;

public class Sistema { 
    public static void main(string[] args)
    {
        ManejoXML obj = new ManejoXML();

        int option = 1;
        while (option > 0) {
            mostrarMenu();
            option = int.Parse(Console.ReadLine());
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

    public void cargarArchivos() { }
    public void ejecutarMisiones() { }
    public void MisionRescate() { }
    public void MisionExtraccion() { }
}