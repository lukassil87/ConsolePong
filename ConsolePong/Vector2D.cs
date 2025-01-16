using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Vector2D
    {
        //Komplexität: simpel

        int x;
        int y;

        /* T0-Klasse 00 - Aufgabe_1
        * 
        * Implementiere die zwei gegebenen Properties (Eigenschaften), welche je folgende Werte zurückliefern und setzen sollen:
        * - x
        * - y
        */

        public int X { get { return 0; } set { } } // TODO A_1
        public int Y { get { return 0; } set { } } // TODO A_1


        public Vector2D (int x, int y)
        {
            /* T0-Klasse 00 - Aufgabe_2
             * 
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
            */

            // TODO A_2
        }

        // Überladung des Plus-Operators
        public static Vector2D operator + (Vector2D v1, Vector2D v2)
        {
            /* T0-Klasse 00 - Aufgabe_3
             * 
             * Implementiere das return Statement für die Überladung des Plus-Operators
             * Gib als Rückgabewert je die addierten Koordinaten der Eingabe-Vektoren in einem Ergebnisvektor zurück
             * 
             * Zu verwendende Methoden und Eigenschaften:
             * - new Vector2D(<X>, <Y>)
             * - v1.X/Y
             * - v2.X/Y
            */

            return null; // TODO A_3
        }

        // ToString Mehtode zum testen der Addition + allgemeines testen empfohlen
        public override string ToString()
        {
            return $"(x:{x}, y:{y})";
        }
    }
}
