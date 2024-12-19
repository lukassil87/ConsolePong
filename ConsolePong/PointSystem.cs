using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class PointSystem
    {
        /* T4-Klasse 05 - Aufgabe_1
         * 
         * Füge die im Notebook beschriebenen Felder zum Speichern der Punktezahl hinzu
         * Gib den Wert der Felder in der DrawScores() Methode an der entsprechenden stelle aus
        */

        private int playerLeftScore = 0; // TODO A_1
        private int playerRightScore = 0; // TODO A_1
        private int playerTopScore = 0; // TODO A_1

        private Ball ball;

        private Paddle paddleLeft;
        private ConsoleColor paddleLeftColor;
        private Paddle paddleRight;
        private ConsoleColor paddleRightColor;

        private Vector2D fieldSize;
        private int paddleOffset;
        private ConsoleColor ballColor;

        private int newBallDelay = 1500;

        public PointSystem(Ball ball, Paddle paddleLeft, ConsoleColor paddleLeftColor, Paddle paddleRight, ConsoleColor paddleRightColor,
            Vector2D fieldSize, int paddleOffset, ConsoleColor ballColor)
        {
            /* T4-Klasse 05 - Aufgabe_2
             * 
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
            */

            // TODO A_2
            this.ball = ball;
            this.paddleLeft = paddleLeft;
            this.paddleLeftColor = paddleLeftColor;
            this.paddleRight = paddleRight;
            this.paddleRightColor = paddleRightColor;
            this.fieldSize = fieldSize;
            this.paddleOffset = paddleOffset;
            this.ballColor = ballColor;
        }

        // Konsolenausgabe
        public void DrawScores()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = paddleLeftColor;
            Console.SetCursorPosition(paddleOffset - 1 + (fieldSize.X / 2 - paddleOffset) / 2, 1);
            Console.Write(playerLeftScore);
            Console.ForegroundColor = paddleRightColor;
            Console.SetCursorPosition(fieldSize.X / 2 + (fieldSize.X / 2 - paddleOffset) / 3, 1);
            Console.Write(playerRightScore);
            Console.ForegroundColor = foregroundColor;
        }

        //Spiel an die Ausgangsposition setzen:
        public void PointReset()
        {
            ball.Color = ConsoleColor.Red;
            ball.Draw();
            ball.Color = ballColor;
            System.Threading.Thread.Sleep(newBallDelay);
            DrawScores();
            paddleLeft.Reset();
            paddleLeft.Draw();
            paddleRight.Reset();
            paddleRight.Draw();
            ball.Reset();
            ball.Draw();
            System.Threading.Thread.Sleep(newBallDelay);
        }

        public string CheckScore(Vector2D ballPosition)
        {
            /* T4-Klasse 05 - Aufgabe_3
             * 
             * Überprüfe mittels der übergebenen Ball-Position ob der Ball den linken oder rechten Spielfeldrand berührt
             * Erhöhe den Punktestand des entsprechenden Spielers, je nachdem auf welcher Seiter der Ball ankommt
             * Setze nach dem erhähen des Punktestands das Spielfeld zurück
             * 
             * Zu verwendende Methoden und Eigenschaften:
             * - playerLeftScore
             * - playerRightScore
             * - PointReset()
             * - fieldSize.X
            */
            if (ballPosition.X == 0) { playerRightScore++; PointReset(); return "right player score test string (do not delete)"; } // TODO A_3
            if (ballPosition.X == fieldSize.X - 1) { playerLeftScore++; PointReset(); return "left player score test string (do not delete)"; } // TODO A_3
            return "no return test string (do not delete)";
        }
    }
}
