public class TraductorBasico
{
    // Diccionario Español -> Inglés
    public static Dictionary<string, string> palabras = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"casa", "house"},
        {"libro", "book"},
        {"silla", "chair"},
        {"mesa", "table"},
        {"ventana", "window"},
        {"puerta", "door"},
        {"coche", "car"},
        {"ciudad", "city"},
        {"calle", "street"},
        {"escuela", "school"},
        {"maestro", "teacher"},
        {"estudiante", "student"},
        {"agua", "water"},
        {"fuego", "fire"},
        {"tierra", "earth"},
        {"aire", "air"},
        {"comida", "food"},
        {"fruta", "fruit"},
        {"pan", "bread"},
        {"leche", "milk"},
        {"café", "coffee"},
        {"té", "tea"},
        {"cerveza", "beer"},
        {"vino", "wine"},
        {"amigo", "friend"},
        {"enemigo", "enemy"},
        {"familia", "family"},
        {"padre", "father"},
        {"madre", "mother"},
        {"hermano", "brother"},
        {"hermana", "sister"},
        {"color", "color"},
        {"ropa", "clothes"},
        {"zapato", "shoe"},
        {"camisa", "shirt"},
        {"pantalón", "pants"},
        {"computadora", "computer"},
        {"teléfono", "phone"},
        {"trabajo", "work"},
        {"dinero", "money"},
        {"tiempo", "time"},
        {"día", "day"},
        {"noche", "night"},
        {"mañana", "morning"},
        {"tarde", "afternoon"},
        {"semana", "week"},
        {"mes", "month"},
        {"año", "year"},
        {"uno", "one"},
        {"dos", "two"},
        {"tres", "three"},
        {"amarillo", "yellow"},
        {"azul", "blue"}        
    };

    // Método para traducir frases
    public static string HacerTraduccion(string texto)
    {
        string[] lista = texto.Split(' '); // separar palabras
        for (int i = 0; i < lista.Length; i++)
        {
            string limpio = lista[i].Trim(new char[] { '.', ',', ';', '!', '?' });
            if (palabras.ContainsKey(limpio.ToLower()))
            {
                lista[i] = lista[i].Replace(limpio, palabras[limpio.ToLower()]);
            }
        }
        return string.Join(" ", lista); // unir palabras traducidas
    }

    // Método para agregar palabras
    public static void AñadirPalabra()
    {
        Console.Write("\nEscriba la palabra en español: ");
        string espanol = Console.ReadLine();

        if (palabras.ContainsKey(espanol.ToLower()))
        {
            Console.WriteLine("Esa palabra ya existe en el diccionario.");
            return;
        }

        Console.Write("Escriba la traducción en inglés: ");
        string ingles = Console.ReadLine();

        palabras.Add(espanol.ToLower(), ingles.ToLower());
        Console.WriteLine($"======== Palabra agregada: {espanol} => {ingles} ========");
    }

    // Método para mostrar palabras
    public static void VerPalabras()
    {
        Console.WriteLine("\n============ PALABRAS EN EL DICCIONARIO ============");
        foreach (var par in palabras)
        {
            Console.WriteLine($"{par.Key} => {par.Value}");
        }
    }

    // Programa principal
    public static void Main(string[] args)
    {
        int menu;
        do
        {
            Console.WriteLine("\n====================== MENÚ ======================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabra");
            Console.WriteLine("3. Ver todas las palabras");
            Console.WriteLine("0. Salir");
            Console.WriteLine("====================================================");
            Console.Write("Seleccione: ");
            menu = int.Parse(Console.ReadLine());


            if (menu == 1)
            {
                Console.Write("\nIngrese la frase en español: ");
                string entrada = Console.ReadLine();
                Console.WriteLine("Traducción: " + HacerTraduccion(entrada));
            }
            else if (menu == 2)
            {
                AñadirPalabra();
            }
            else if (menu == 3)
            {
                VerPalabras();
            }
            else if (menu == 0)
            {
                Console.WriteLine("Programa finalizado...");
            }
            else
            {
                Console.WriteLine("Opción inválida, intente otra vez.");
            }

        } while (menu != 0);
    }
}