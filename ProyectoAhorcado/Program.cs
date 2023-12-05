using System;

class Program
{
    static void Main()
    {
        // Palabra que se debe adivinar
        string palabraSecreta = ObtenerPalabraSecreta();

        // Estado actual de la palabra mostrar al jugador
        char[] palabraMostrada = new char[palabraSecreta.Length];
        for (int i = 0; i < palabraMostrada.Length; i++)
        {
            palabraMostrada[i] = '_';
        }

        // Los intentos que se le daran al jugador
        int intentosRestantes = 6;

        while (intentosRestantes > 0)
        {
            // Se muestra la palabra y los intentos
            MostrarEstadoJuego(palabraMostrada, intentosRestantes);

            // Se obtiene la letra al jugador
            char letra = ObtenerLetra();

            // Debe verificar si es la palabra
            bool letraAdivinada = ActualizarPalabraMostrada(letra, palabraSecreta, palabraMostrada);

            // Se verifica si el jugador adivino la palabra
            if (Array.IndexOf(palabraMostrada, '_') == -1)
            {
                Console.WriteLine("¡Felicidades! Has adivinado la palabra: " + palabraSecreta);
                break;
            }

            // Reduce los intentos si falla en la palabra
            if (!letraAdivinada)
            {
                DibujarAhorcado(6 - intentosRestantes);
                intentosRestantes--;
            }
        }

        // Muestra el resultado final
        if (intentosRestantes == 0)
        {
            Console.WriteLine("¡Oh no! Has agotado tus intentos. La palabra era: " + palabraSecreta);
            DibujarAhorcado(6);
        }
    }
    //Alexis Manuel Espinoza Martinez - Interfaz de Usuario
    //Este método muestra el estado actual del juego en la consola
    static void MostrarEstadoJuego(char[] palabraMostrada, int intentosRestantes)
    {
        Console.WriteLine("Palabra: " + string.Join(" ", palabraMostrada));//Array que muestra al jugador las letras adivinadas reveladas y las que no estan ocultas
        Console.WriteLine("Intentos restantes: " + intentosRestantes);//Numero que muestra la cantidad de vidas/intentos que le quedan al jugador
    }
    //Metodo que solicita al jugador que ingrese una letra
    static char ObtenerLetra()
    {
        Console.Write("Ingresa una letra: ");
        return Console.ReadLine()[0];// Devuelve el primer caracter de entrada del usuario
    }
    // Este método actualiza el array palabraMostrada con las letras adivinadas
    static bool ActualizarPalabraMostrada(char letra, string palabraSecreta, char[] palabraMostrada)//letra adivinada por el jugador, la palabra que el jugador intenta adivinar, estado actual de la palabra
    {
        //El ciclo pasa sobre cada letra de la palabra a adivinar (palabraSecreta) y compara si coincide con la letra ingresada, de ser asi actualiza la posicion en palabraMostrada con la letra adivinada y establece letraAdivinada a true
        bool letraAdivinada = false;
        for (int i = 0; i < palabraSecreta.Length; i++)
        {
            if (char.ToUpper(palabraSecreta[i]) == char.ToUpper(letra))
            {
                palabraMostrada[i] = palabraSecreta[i];
                letraAdivinada = true;
            }
        }
        return letraAdivinada;
    }
    //Alan Omar Rendon Martinez(Estructura)
    static void DibujarAhorcado(int errores)
    {
        switch (errores)
        {
            //El codigo funciona para actualizar el monito cada vez que se equivoque al ingrsar una letra incorrecta usando un switch para agregar
            // y actualizar el disño del monito, una vez completado el monito se imprimira que el usuario ha perdido  
            case 1:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                break;
            case 2:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                break;
            case 3:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                break;
            case 4:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" -|   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                break;
            case 5:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" -|-  |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                break;
            case 6:
                Console.WriteLine("  +---+");
                Console.WriteLine("  |   |");
                Console.WriteLine("  O   |");
                Console.WriteLine(" -|-  |");
                Console.WriteLine(" -+-  |");
                Console.WriteLine("      |");
                Console.WriteLine("GAME OVER");
                break;
            default:
                break;
        }
    }
}
