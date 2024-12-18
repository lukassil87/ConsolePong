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
                //velocity.X *= -1;
            }
            return false;
        }

        public static bool paddleRightCollision(Vector2D ballPosition, Paddle paddleRight, ref Vector2D ballVelocity)
        {
            /* T5-Klasse 06 - Aufgabe_1
             * 
             * Implementiere entsprechend des linken Paddles die Kollisonsbehandlung für das rechte Paddle
             * Übernimm die berteits gegebene funktionalität des rechten Paddles und führe nötigen Änderungen durch
             * 
             * Folgendes ist zu beachten:
             * - paddleLeft ist an allen Stellen durch paddleRight zu ersetzen
             * - die nötigen Änderungen beschränken sich ausschließlich auf das Invertieren von Pperatoren und Vorzeichen
             *      - (+ ↔ -) "Plus zu Minus und umgekehrt" 
             *      - (< ↔ >) "Kleiner zu Größer und umgekehrt"
             *      - (<= ↔ >=) "Kleinergleich zu Größergleich und umgekehrt"
             * 
             * NOTE: Das Arbeiten mit einer Skizze des Spielfelds und Koordinatensystems hilft beim Lösen der Aufgabe
            */

            // TODO A_1

            return false;
        }
    }
}
