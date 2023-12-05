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

        Console.ReadLine();
    }
}
