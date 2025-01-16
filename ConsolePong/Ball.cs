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
         * Implementiere die gegebenen Property (Setter), sodass der übergebene Wert im Feld color gespeichert wird
        */
        public ConsoleColor Color { set { } get { return color; } } // TODO A_3
        public Vector2D Position { get { return positionNew; } } // Test-Property
        public Vector2D Velocity { get { return velocity; } } // Test-Property

        private Random random = new Random();

        // Konstruktor:
        public Ball(char character, ConsoleColor color, Vector2D fieldSize)
        {
            /* T3-Klasse 04 - Aufgabe_1
             * 
             * Die Startposition soll mit dem richtigen Wert initialisiert werden
             * 
             * Folgendes ist zu beachten:
             * - Startposition = Mitte des Spielfelds
             *      - berechne den Startpositions-Vektor mittels der folgenden Eigenschaften:
             *           - fieldSize.X
             *           - fieldSize.Y
             * 
             * TIPP: Um die Mitte der Y-Koordinate zu erhalten muss zusätzlich 1 davon abgezogen werden (-1)
            */
            this.character = character;
            this.color = color;
            this.fieldSize = fieldSize;

            positionStart = new Vector2D(0, 0); // TODO A_1

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
            positionNew = positionStart;

            /* T3-Klasse 04 - Aufgabe_2
             * 
             * Abhängig von dem in Zeile 28 definierten Random-Objekt (random) soll die Startrichtung des Balls bestimmt werden
             * Ersetze die Werte "42" in der Abfrage unten durch die gewünschte Funktionalität
             * 
             * 
             * Folgendes ist zu beachten:
             * 
             * 1. die Chance, dass sich der Ball nach links oder rechts bewegt, beträgt 50/50
             * 
             * 2. die Geschwindigkeit des Balls entspricht der im Konstruktor
             * 
             * 3. die Startbewegung des Ball ist wie beim Spielstart ausschließlich horizontal (<- Ball ->)
            */

            if ( random.Next(0,42) == 0 /*TODO A_2*/ )
                velocity = new Vector2D(42, 42); // TODO A_2
            else
                velocity = new Vector2D(42, 42); // TODO A_2
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
