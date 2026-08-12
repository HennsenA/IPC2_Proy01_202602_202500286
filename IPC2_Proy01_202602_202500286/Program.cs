public class Sistema { 
    public static void main(string[] args)
    {
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

public class ChapinRobots {
    private String nombre { get; set; }
    private bool estado { get; set; }

    public ChapinRobots(String nombre) 
    {
        this.nombre = nombre;
        this.estado = true;
    }
}

public class ChapinRescue : ChapinRobots {
    public ChapinRescue(String nombre, bool estado): base(nombre) {}
    public void rescatar() { 
    }
}

public class ChapinFighter : ChapinRobots {
    public ChapinFighter(String nombre, bool estado): base(nombre) { }
    public void extraer() { }
    public void combatir() { }
}