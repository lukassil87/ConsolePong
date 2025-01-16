using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Paddle
    {
        char character;
        ConsoleColor color;
        Vector2D fieldSize;
        Vector2D positionNew;
        Vector2D positionOld;
        Vector2D positionStart;
        int size;
        int speed;


        /* T2-Klasse 03 - Aufgabe_1
         * 
         * Implementiere die zwei gegebenen Properties (Eigenschaften), welche je folgende Werte zurückliefern sollen:
         * - positionNew
         * - size
        */

        public Vector2D Position => throw new NotImplementedException("Die Property 'Position' wurde noch nicht in Paddle implementiert"); // TODO A_1
        public int Size => throw new NotImplementedException("Die Property 'Size' wurde noch nicht in Paddle implementiert"); // TODO A_1

        // Konstruktor:
        public Paddle (char character, int size, ConsoleColor color, Vector2D position, int speed, Vector2D fieldSize)
        {
            /* T2-Klasse 03 - Aufgabe_2
             * 
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
             * 
             * Folgendes ist zu beachten:
             * - size darf minimal den Wert 3 erhalten (wenn size < 3, soll sie auf 3 gesetzt werden)
             * - alle position-Felder (start/old/new) übernehmen den gleichen Initialwert (Vector2D position)
            */

            // TODO A_2

        }

        // Aktualisierung der Position
        public virtual void Update(string move)
        {
            switch (move)
            {
                /* T2-Klasse 03 - Aufgabe_3
                 * 
                 * Für den Fall "up" soll sich der Schläger nach oben bewegen.
                 * Für den Fall "down" soll sich der Schläger nach unten bewegen.
                 * Dazu wird die alte Position des Schlägers genommen und mit der gespeicherten Geschwindikeit (speed) angepasst.
                 * Addiere oder Subtrahiere (+ / -) speed von positionOld.Y, sodass das gewünschte Verhalten auftritt!
                 * 
                 * TIPP: Achte auf den Aufbau des 
                */

                case "up":

                    // TODO A_3
                    positionNew.Y = positionOld.Y; // (+ / -) speed

                    if (positionNew.Y < 0) positionNew.Y = 0;  // NOTE: überprüft ob der Schläger den oberen Rand erreicht, wenn ja -> Bewegung/Position wird zurückgesetzt
                    break;
                case "down":

                    // TODO A_3
                    positionNew.Y = positionOld.Y; // (+ / -) speed

                    if (positionNew.Y > fieldSize.Y - size) positionNew.Y = fieldSize.Y - size; // NOTE: überprüft ob der Schläger den unteren Rand erreicht, wenn ja -> Bewegung/Position wird zurückgesetzt
                    break;
            }
        }

        //Schläger an die Startposition setzen:
        public void Reset()
        {
            positionNew = positionStart;
        }

        // Konsolenausgabe
        public void Draw()
        {
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(positionOld.X, positionOld.Y + i);
                Console.Write(' ');
            }
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(positionNew.X, positionNew.Y + i);
                Console.Write(character);
            }
            Console.ForegroundColor = foregroundColor;
            UpdatePosition();
        }

        public void UpdatePosition() { positionOld = positionNew; }
    }
}
