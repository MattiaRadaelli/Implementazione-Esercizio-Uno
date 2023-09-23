﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementazione_Esercizio_Uno
{
    internal class Program
    {
        static bool Ins(int[] array, int numero, int posizione, ref int indice)
        {
            bool inserito = true;
            if (indice < array.Length)
            {
                indice++;
                for (int i = indice; i > posizione; i--)
                {
                    array[i] = array[i - 1];
                }
                array[posizione] = numero;
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }
        static bool Coda(int[] array, int numero, ref int indice)
        {
            bool inserito = true;
            if (indice < array.Length)
            {
                array[indice] = numero;
                indice++;
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }

        static string Html(int[] array, ref int indice)
        {
            string s;
            s = "<!DOCTYPE html>\r\n<html lang=\"it\">\r\n    <head>\r\n    <title>Visualizzazione dell'array</title>\r\n  </head>\r\n  <body>\r\n    <table>\r\n    <tr>";
            for (int i = 0; i < indice; i++)
            {
                s += $"<td> {array[i]} </td>";
            }
            s += $"</tr>\r\n    </table>\r\n    </body>\r\n</html>";
            return s;
        }

        static int Pos(int[] array, int numero, ref int indice)
        {
            int posizione = -1;
            for (int i = 0; i < indice; i++)
            {
                if (array[i] == numero)
                {
                    posizione = i;
                }
            }
            return posizione;
        }

        static bool Canc(int[] array, int numero, ref int indice)
        {
            bool inserito = true;
            if (indice > 0)
            {
                for (int i = 0; i < indice; i++)
                {
                    if (array[i] == numero)
                    {
                        for (; i < indice - 1; i++)
                        {
                            array[i] = array[i + 1];
                        }
                        indice--;
                        break;
                    }
                }
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }
        static int[] Split(string array2, ref int indice, ref int [] array)
        {
            int i = 0;
            string frase = "";
            while (2<3)
            {
                if (array2[i] == ',')
                {
                    array[indice] = Convert.ToInt16(frase);
                    indice++;
                    frase = "";
                }
                else
                {
                    frase += array2[i];
                }

                if (i == array2.Length - 1)
                {
                    array[indice] = Convert.ToInt16(frase);
                    return array;
                }
                i++;
            }
        }
        static void Main(string[] args)
        {
            int[] arr1 = new int[100];    //dichiarazione dell'array array1
            int c, n, p;                    //dichiarazione delle variabili c, n, p; rispettivamente la variabile della posizione dell'ultimo valore, la variabile che degli gli input e la variabile della posizione ricevuta in input
            bool r = false;                 //variabile booleana per l'uscita dal ciclo do while
            do                              //ciclo do while che verifica che l'input ricevuto sia compreso tra 0 e 25(per questione di comodità)
            {
                Console.WriteLine("Inserire numero di elementi iniziale: (0 < N < 25)");    //output del messaggio "Inserire numero di elementi iniziale: (0 < N < 25)"
                c = int.Parse(Console.ReadLine());                                          //assegnazione a c del valore ricevuto in input dall'utente
            } while (c < 0 || c > 25);                                                      //codizione che verifica che c sia <0 o >25 per ripetere il ciclo
            for (byte i = 0; i < c; i++)                                                    //ciclo for per chiedere all'utente l'input c volte
            {
                Console.WriteLine($"Inserire elemento iniziale in posizione {i}: ");        //output del messaggio "Inserire elemento iniziale in posizione {i}: " con {i} sostituito dal valore di i
                arr1[i] = int.Parse(Console.ReadLine());                                  //salvataggio in array1[i] del valore ricevuto in input
            }
            Console.Clear();    //reset della console
            do                  //ciclo do while che verifica se ripetere il programma o chiuderlo
            {
                Console.WriteLine("Inserire la lettera associata alla funzione per selezionarla: \r\na - Aggiungere un elemento in coda all'array\r\nv - Visualizzare l'array che restituisca la stringa in HTML\r\nr - Ricerca un numero all'interno dell'array\r\nc - Cancellazione di un elemento nell'array\r\ni - Inserimento di un valore in una posizione dell'array\r\ns - Stampa dell'array aggiornato\r\nf - Inserire numeri dal file\r\nn - Nuovi numeri random\r\no - Aggiungere un elemento nell'array e ordinarlo\r\nt - Troncare l'array\r\nu - Uscita dal programma"); //output delle indicazioni
                switch (Console.ReadLine())         //switch che verifica l'input ricevuto
                {
                    case "a":
                        Console.WriteLine("Inserire un elemento in coda: ");
                        n = int.Parse(Console.ReadLine());
                        if (Coda(arr1, n, ref c) == true)
                        {
                            Console.WriteLine("Elemento inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case "v":
                        Console.WriteLine(Html(arr1, ref c));
                        break;
                    case "r":
                        Console.WriteLine("Inserire numero da ricercare: ");
                        n = int.Parse(Console.ReadLine());
                        p = Pos(arr1, n, ref c);
                        Console.WriteLine($"Il numero {n} si trova in posizione {p}");
                        break;
                    case "c":
                        Console.WriteLine("Inserire elemento da cencellare: ");
                        n = int.Parse(Console.ReadLine());
                        if ((Canc(arr1, n, ref c)))
                        {
                            Console.WriteLine("Elemento cancellato correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array vuoto");
                        }
                        break;
                    case "i":
                        Console.WriteLine("Inserire elemento: ");
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire posizione dove aggiungere l'elemento: ");
                        p = int.Parse(Console.ReadLine());
                        if (Ins(arr1, n, p, ref c) == true)
                        {
                            Console.WriteLine("Elemento inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case "s":
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(arr1[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "u":
                        r = true;
                        break;
                    case "f":
                        StreamReader lettore = new StreamReader("Numeri.txt");
                        string file = lettore.ReadLine();
                        lettore.Close();
                        arr1 = Split(file, ref c, ref arr1);
                        break;
                    case "n":
                        Random rmd = new Random();
                        Console.WriteLine("Quanti numeri random vuoi?");
                        int numerirandom = int.Parse(Console.ReadLine());
                        Console.WriteLine("inserisci numero limite minimo");
                        int limitemin = int.Parse(Console.ReadLine());
                        Console.WriteLine("inserisci numero limite massimo");
                        int limitemax = int.Parse(Console.ReadLine());
                        for (; numerirandom > 0; numerirandom--)
                        {
                            arr1[c] = rmd.Next(limitemin, limitemax + 1);
                            c++;
                        }
                        break;
                    case "t":
                        Console.WriteLine("A quanto vuoi troncare l'array?");
                        int tronc = int.Parse(Console.ReadLine());
                        arr1 = new int[tronc];
                        break;
                    case "o":
                        Console.WriteLine("Che numero vuoi inserire?");
                        int numeroordin = int.Parse(Console.ReadLine());
                        arr1[c] = numeroordin;
                        c++;
                        int scambio = 0;
                        for (int i = 0; i < arr1.Length - 1; i++)
                            if (arr1[i] > arr1[i + 1])
                            {
                                scambio = arr1[i];
                                arr1[i] = arr1[i + 1];
                                arr1[i + 1] = scambio;
                            }
                        break;
                    default:
                        Console.WriteLine("Opzione non valida");
                        break;
                    }
                Console.WriteLine("Premere un tasto per continuare");
                Console.ReadKey();
                Console.Clear();
            } while (r == false);
        }

        

        
    }
}
