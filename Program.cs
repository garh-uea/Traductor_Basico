namespace TraductorBasico
{
    class Traductor
    {
        // Diccionario de traducción Español -> Inglés
        private Dictionary<string, string> diccionario;

        public Traductor()
        {
            diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"casa", "house"},
                {"perro", "dog"},
                {"gato", "cat"},
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
                {"sol", "sun"},
                {"luna", "moon"},
                {"estrella", "star"},
                {"mar", "sea"},
                {"rio", "river"},
                {"montaña", "mountain"},
                {"bosque", "forest"},
                {"flor", "flower"},
                {"árbol", "tree"},
                {"pájaro", "bird"},
                {"pez", "fish"},
                {"caballo", "horse"},
                {"vaca", "cow"},
                {"cerdo", "pig"},
                {"oveja", "sheep"},
                {"color", "color"},
                {"ropa", "clothes"}
            };
        }

        // Método para traducir frases
        public string TraducirFrase(string frase)
        {
            string[] palabras = frase.Split(' '); 
            for (int i = 0; i < palabras.Length; i++)
            {
                string palabraLimpia = palabras[i].Trim(new char[] { '.', ',', ';', '!', '?' });

                if (diccionario.ContainsKey(palabraLimpia.ToLower()))
                {
                    palabras[i] = palabras[i].Replace(palabraLimpia, diccionario[palabraLimpia.ToLower()]);
                }
            }
            return string.Join(" ", palabras);
        }

        // Método para agregar nuevas palabras
        public void AgregarPalabra()
        {
            string esp;
            do
            {
                Console.Write("\nIngrese la palabra en español: ");
                esp = Console.ReadLine();

                if (diccionario.ContainsKey(esp.ToLower()))
                {
                    Console.WriteLine("La palabra ya existe en el diccionario. Ingrese otra.");
                }
                else
                {
                    break;
                }

            } while (true);

            Console.Write("Ingrese la traducción en inglés: ");
            string eng = Console.ReadLine();

            diccionario.Add(esp.ToLower(), eng.ToLower());
            Console.WriteLine($"✅ Palabra agregada: {esp} -> {eng}");
        }

        // Método para mostrar todas las palabras actuales
        public void MostrarPalabras()
        {
            Console.WriteLine("\n============ LISTADO DE PALABRAS EN EL DICCIONARIO: ============");
            foreach (var par in diccionario)
            {
                Console.WriteLine($"- {par.Key} -> {par.Value}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Traductor traductor = new Traductor();
            int opcion;

            do
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("3. Mostrar listado de palabras actuales");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("\nIngrese la frase en español: ");
                        string frase = Console.ReadLine();
                        string traduccion = traductor.TraducirFrase(frase);
                        Console.WriteLine("Traducción parcial: " + traduccion);
                        break;

                    case 2:
                        traductor.AgregarPalabra();
                        break;

                    case 3:
                        traductor.MostrarPalabras();
                        break;

                    case 0:
                        Console.WriteLine("======= Saliendo del programa... =======");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}
