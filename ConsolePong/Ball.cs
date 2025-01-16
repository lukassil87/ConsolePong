using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Ball
    {
        char character;
        ConsoleColor color;
        Vector2D fieldSize;
        Vector2D positionNew;
        Vector2D positionOld;
        Vector2D positionStart;
        Vector2D velocity;

        /* T3-Klasse 04 - Aufgabe_3
         * 
         * Implementiere die gegebenen Property, sodass der übergebene Wert in folgendem Feld gespeichert wird:
         * - color
        */
        public ConsoleColor Color { set { color = value; } get { return color; } } // TODO A_3
        public Vector2D Position { get { return positionNew; } } // Test-Property
        public Vector2D Velocity { get { return velocity; } } // Test-Property

        private Random random = new Random(); // TODO A_2

        // Konstruktor:
        public Ball(char character, ConsoleColor color, Vector2D fieldSize)
        {
            /* T3-Klasse 04 - Aufgabe_1
             * 
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
             * Weiters sollten die position-Felder und velocity mit passenden Werten initialisiert werden
             * 
             * Folgendes ist zu beachten:
             * - die Startposition entspricht der Mitte des Spielfelds
             *      - berechne den Positions-Vektor mittels der gegebenen Eigenschaften
             * - alle position-Felder (start/old/new) übernehmen den gleichen Initialwert
             *      - übergib den Wert der Startposition an die weiteren position-Felder
             * - der Ball bewegt sich zum Spielstart ausschließlich horizontal (<- Ball ->)
             *      - setze den Y-Wert des Bewegungs Vektors initial auf 0
             * 
             * Für die Berechnung der Initialwerte (position, veloctiy) werden folgende Methoden und Eigenschaften benötigt:
             * - new Vector2D (<X>, <Y>)
             * - fieldSize.X
             * - fieldSize.Y
            */

            // TODO A_1
            this.character = character;
            this.color = color;
            this.fieldSize = fieldSize;
            // Startpostion:
            positionStart = new Vector2D(fieldSize.X / 2, fieldSize.Y / 2 - 1);
            positionNew = positionStart;
            positionOld = positionStart;
            // Startgeschwindigkeitsvektor:
            velocity = new Vector2D(4, 0);
        }

        // Aktualisierung der Position:
        public void Update(Paddle paddleLeft, Paddle paddleRight)
        {
            positionNew = positionOld + velocity;

            // Kollision mit Spielfeldrändern:
            if (positionNew.X < 0) { positionNew.X = 0; velocity.X *= -1; }
            if (positionNew.X > fieldSize.X - 1) { positionNew.X = fieldSize.X - 1; velocity.X *= -1; }
            if (positionNew.Y < 0) { positionNew.Y = 0; velocity.Y *= -1; }
            if (positionNew.Y > fieldSize.Y - 1) { positionNew.Y = fieldSize.Y - 1; velocity.Y *= -1; }

            // Zeilenverschub in der rechten unteren Ecke verhindern:
            if (positionNew.X == fieldSize.X - 1 && positionNew.Y == fieldSize.Y - 1)
            {
                positionNew.Y = fieldSize.Y - 2; positionNew.X = fieldSize.X - 2;
                velocity.X = -1; velocity.Y *= -1;
            }

            // Kollision mit paddle Left:
            if (CollisionDetection.paddleLeftCollision(positionNew, paddleLeft, ref velocity))
                positionNew.X = paddleLeft.Position.X + 1;
            //velocity.X *= -1;
            if (CollisionDetection.paddleRightCollision(positionNew, paddleRight, ref velocity))
                positionNew.X = paddleRight.Position.X - 1;
            //velocity.X *= -1;
        }


        //Ball an die Startposition setzen:
        public void Reset()
        {
            /* T3-Klasse 04 - Aufgabe_2
             * 
             * Füge das im Notebook gegebene Random-Objekt als privates Feld zur Klasse hinzu
             * Abhängig von diesem soll die Startrichtung des Balls bestimmt werden
             * Ersetze die null-Werte in der Abfrage unten durch die gewünschte Funktionalität
             * 
             * Folgendes ist zu beachten:
             * - die Startbewegung des Ball ist wie beim Spielstart ausschließlich horizontal (<- Ball ->)
             * - die Geschwindigkeit des Balls entspricht der im Konstruktor
             * - die Chance, dass sich der Ball nach links oder rechts bewegt, beträgt 50/50
            */
            positionNew = positionStart; // TODO A_2
            if (random.Next(0, 2) == 0)
                velocity = new Vector2D(4, 0); // TODO A_2
            else
                velocity = new Vector2D(-4, 0); // TODO A_2
        }

        // Konsolenausgabe
        public Vector2D Draw()
        {
            Console.SetCursorPosition(positionOld.X, positionOld.Y);
            Console.Write(' ');
            Console.SetCursorPosition(positionNew.X, positionNew.Y);
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = foregroundColor;
            positionOld = positionNew;
            return positionNew;
        }

    }
}
