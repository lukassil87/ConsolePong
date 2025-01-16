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
         * 
         * TIPP: Aktuell wird inkorrekterweise in der DrawScores() Methode "playerLeftScore" und "playerRightScore" als string ausgegeben
        */

        // TODO A_1

        private Ball ball;

        private Paddle paddleLeft;
        private ConsoleColor paddleLeftColor;
        private Paddle paddleRight;
        private ConsoleColor paddleRightColor;

        private Vector2D fieldSize;
        private int paddleOffset;
        private ConsoleColor ballColor;

        private int newBallDelay = 1500;

        //Konstruktor
        public PointSystem(Ball ball, Paddle paddleLeft, ConsoleColor paddleLeftColor, Paddle paddleRight, ConsoleColor paddleRightColor, 
            Vector2D fieldSize, int paddleOffset, ConsoleColor ballColor)
        {
            /* T4-Klasse 05 - Aufgabe_2
             * 
             * Implementiere den Konstruktor, sodass die übergebenen Werte in die Felder der Klasse gespeichert werden
            */

            // TODO A_2
        }

        // Konsolenausgabe
        public void DrawScores()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = paddleLeftColor;
            Console.SetCursorPosition(paddleOffset - 1 + (fieldSize.X / 2 - paddleOffset) / 2, 1);
            Console.Write("playerLeftScore");
            Console.ForegroundColor = paddleRightColor;
            Console.SetCursorPosition(fieldSize.X / 2 + (fieldSize.X / 2 - paddleOffset) / 3, 1);
            Console.Write("playerRightScore");
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
             * Überprüfe mittels der übergebenen Ball-Position ob der Ball den linken oder rechten Spielfeldrand berührt ("null" erstetzen) [fieldSize.X]
             * 
             * Dann erhöhe den Punktestand des entsprechenden Spielers um 1, je nachdem auf welcher Seiter der Ball ankommt [playerRightScore/playerLeftScore]
             * 
             * Dann setze nach dem erhähen des Punktestands das Spielfeld zurück [PointReset()]
             * 
             * Zu verwendende Methoden und Eigenschaften:
             * - fieldSize.X
             * - playerRightScore
             * - playerLeftScore
             * - PointReset()
             * 
             * TIPP: Die fieldSize verhällt sich ähnliche der Nummerierung eines Arrays, die erste Stelle entspricht somit 0 und die letze ist um 1 geringer als die gesamte fieldSize
            */
            if (ballPosition.X == null) { /* TODO A_3 */ return "right player score test string (do not delete)"; }
            if (ballPosition.X == null) { /* TODO A_3 */ return "left player score test string (do not delete)"; }

            return "no return test string (do not delete)";
        }
    }
}
