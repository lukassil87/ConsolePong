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
         * Implementiere die zwei gegebenen Properties (Eigenschaften), welche je folgende Werte zurückliefern sollen:
         * - positionNew
         * - size
        */

        public int Size { get { return size; } } // TODO A_1
        public Vector2D Position { get { return positionNew; } } // TODO A_1

        // Konstruktor:
        public Paddle(char character, int size, ConsoleColor color, Vector2D position, int speed, Vector2D fieldSize)
        {
            /* T2-Klasse 03 - Aufgabe_2
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
             * Folgendes ist zu beachten:
             * - size darf minimal den Wert 3 erhalten
             * - alle position-Felder (old/new/start) übernehmen den gleichen Initialwert
            */

            // TODO A_2
            this.character = character;
            if (size < 3) size = 3;
            this.size = size;
            this.color = color;
            positionStart = position;
            positionNew = positionStart;
            positionOld = positionStart;
            this.speed = speed;
            this.fieldSize = fieldSize;
        }

        // Aktualisierung der Position
        public virtual void Update(string move)
        {
            switch (move)
            {
                /* T2-Klasse 03 - Aufgabe_3
                 * 
                 * Berechne die Bewegung des Schlägers je nach übergebenem string nach oben oder unten
                 * Der Schläger soll sich mit der gespeicherten Geschwindikeit (speed) bewegen
                 * 
                 * Zu verwendende Methoden und Eigenschaften:
                 * - positionNew
                 * - new Vector2D
                 * - positionOld.X
                 * - positionOld.Y
                 * - speed
                */

                case "up":
                    positionNew = new Vector2D(positionOld.X, positionOld.Y - speed); // TODO A_3
                    if (positionNew.Y < 0) positionNew.Y = 0;
                    // NOTE: überprüft ob der Schläger den oberen Rand erreicht, wenn ja -> Bewegung/Position wird zurückgesetzt
                    break;
                case "down":
                    positionNew = new Vector2D(positionOld.X, positionOld.Y + speed); // TODO A_3
                    if (positionNew.Y > fieldSize.Y - size) positionNew.Y = fieldSize.Y - size;
                    // NOTE: überprüft ob der Schläger den unteren Rand erreicht, wenn ja -> Bewegung/Position wird zurückgesetzt
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
