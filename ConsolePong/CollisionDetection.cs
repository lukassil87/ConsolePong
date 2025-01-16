using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public static class CollisionDetection
    {
        public static bool paddleLeftCollision(Vector2D ballPosition, Paddle paddleLeft, ref Vector2D ballVelocity)
        {
            // Kollision mit paddle Left:
            if (ballPosition.X <= paddleLeft.Position.X + 1 &&
                ballPosition.X >= paddleLeft.Position.X + ballVelocity.X + 2 &&
                ballPosition.Y >= paddleLeft.Position.Y &&
                ballPosition.Y < paddleLeft.Position.Y + paddleLeft.Size)
            {
                if (ballPosition.Y < paddleLeft.Position.Y + paddleLeft.Size / 3)
                {
                    ballVelocity.X = 4; ballVelocity.Y = -1;
                }
                else if (ballPosition.Y < paddleLeft.Position.Y + 2 + paddleLeft.Size / 3)
                {
                    ballVelocity.X = 4; ballVelocity.Y = 0;
                }
                else
                {
                    ballVelocity.X = 4; ballVelocity.Y = 1;
                }
                return true;
            }
            return false;
        }

        public static bool paddleRightCollision(Vector2D ballPosition, Paddle paddleRight, ref Vector2D ballVelocity)
        {
            /* T5-Klasse 06 - Aufgabe_1
             * 
             * Implementiere entsprechend des linken Paddles die Kollisonsbehandlung für das rechte Paddle
             * Aktuell sind die beiden Abfragen gleich, einzelne Zeilen müssen unten bei TODO_A1 in den jeweiligen TODO-Zeilen verändert werden
             * 
             * Folgendes ist zu beachten:
             * - die nötigen Änderungen beschränken sich ausschließlich auf das Invertieren von Operatoren und Vorzeichen
             *      - (+ ↔ -) "Plus zu Minus und umgekehrt" 
             *      - (< ↔ >) "Kleiner zu Größer und umgekehrt"
             *      - (<= ↔ >=) "Kleinergleich zu Größergleich und umgekehrt"
             * 
             * NOTE: Das Arbeiten mit einer Skizze des Spielfelds und Koordinatensystems hilft beim Lösen der Aufgabe
            */

                // TODO_A1-Start - Kollision mit paddle Right:
            /*TODO-Start*/
            if (ballPosition.X >= paddleRight.Position.X - 1 &&             
                ballPosition.X <= paddleRight.Position.X + ballVelocity.X - 2 &&
                ballPosition.Y >= paddleRight.Position.Y &&
                ballPosition.Y < paddleRight.Position.Y + paddleRight.Size)
            /*TODO-End*/
            {
                if (ballPosition.Y < paddleRight.Position.Y + paddleRight.Size / 3)
                {
                    ballVelocity.X = -4; ballVelocity.Y = -1; // TODO
                }
                else if (ballPosition.Y < paddleRight.Position.Y + 2 + paddleRight.Size / 3)
                {
                    ballVelocity.X = -4; ballVelocity.Y = 0; // TODO
                }
                else
                {
                    ballVelocity.X = -4; ballVelocity.Y = 1; // TODO
                }
                // TODO_A1-End
                return true;
            }
            return false;
        }
    }
}
