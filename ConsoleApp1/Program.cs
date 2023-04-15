using System.Net.Security;

int[,] tablero = new int[5, 5];

void paso1_crear_tablero()
{
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            tablero[i, j] = 0;
        }
    }
}

void paso2_colocar_barco()
{
    //se colocan los barcos alealtoriamente
    
    Random aleal = new Random();

    tablero[aleal.Next(0, 4), aleal.Next(0, 4)] = 1;
    tablero[aleal.Next(0, 4), aleal.Next(0, 4)] = 1;
    tablero[aleal.Next(0, 4), aleal.Next(0, 4)] = 1;
    tablero[aleal.Next(0, 4), aleal.Next(0, 4)] = 1;


}

void paso3_imprimir_tablero()
{
    int col = 0;
    Console.Write("\n\t  0 1 2 3 4 \n");

    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        Console.Write("\t");
        Console.Write(col + "|");
        col++;
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
            String carcter_imprimir;// = (tablero[i, j] ==0 ? "-": "*");

            switch (tablero[i, j])
            {

                case 0:
                    //ESPACIO SIN NADA
                    carcter_imprimir = "^"; 
                    break;

                case 1:
                    //Barco EXISTENTE
                    carcter_imprimir = "B";

                    break;

                case 2:
                    //Le dio
                    carcter_imprimir = "*";
                    break;

                case -1:
                    //no dio
                    carcter_imprimir = "X";
                    break;

                default:
                    carcter_imprimir = "*";
                    break;
            }

            Console.Write(carcter_imprimir + " ");
        }
        Console.WriteLine();
    }

}

void paso4_ingreso_cordenadas()
{
    int Varcos = 3;
    int fila, columna = 0;
    Console.Clear();

    Console.WriteLine("Varcos actualmente: " + Varcos + "\n");

    paso3_imprimir_tablero();
    Console.WriteLine("\n\n");

    bool Rep = true;
    do
    {
        Console.WriteLine("ingresa la Fila: ");
        fila = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("ingresa la Columna: ");
        columna = Convert.ToInt32(Console.ReadLine());

        //en este if delimitamos los intentos repetidos
        if (tablero[fila, columna] == -1 || tablero[fila, columna] == -2)
        {
            Console.WriteLine("Ya has disparado en esa coordenada, selecciona otra.");
        }
        else
        {
            if (tablero[fila, columna] == 1)
            {
                Console.Beep();
                tablero[fila, columna] = -2; //le dio
                Varcos = Varcos - 1;

            }
            else
            {
                tablero[fila, columna] = -1;// Falló
            }
            Console.Clear();
            Console.WriteLine("Varcos actualmente: " + Varcos + "\n");
            paso3_imprimir_tablero();
            Console.WriteLine("\n\n");
        }
        if (Varcos == 0)
        {
            Console.WriteLine("HAS GANADOOOO: ");
            Rep = false;
        }
    } while (Rep);
}


paso1_crear_tablero();
paso2_colocar_barco();
paso3_imprimir_tablero();
paso4_ingreso_cordenadas();