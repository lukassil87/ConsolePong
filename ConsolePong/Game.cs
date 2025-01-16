using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    internal class Game
    {
        private ConsoleColor fieldForeColor = ConsoleColor.Green;
        private Vector2D fieldSize = new Vector2D(80, 25);

        private ConsoleColor fieldBackColor = ConsoleColor.Black;
        private int loopTime = 90;

        private Ball ball;
        private char ballCharacter = '■'; //mit ALT + 254 zeichnen
        private ConsoleColor ballColor = ConsoleColor.Green;

        private char paddleCharacter = '█'; //mit ALT + 219 zeichnen
        private int paddleSize = 4;
        private int paddleSpeed = 1;
        private int paddleOffset = 6;
        private Paddle paddleLeft;
        private ConsoleColor paddleLeftColor = ConsoleColor.Green;

        private Paddle paddleRight;
        private ConsoleColor paddleRightColor = ConsoleColor.Green;

        private bool runGameLoop = true;

        PointSystem game1;

        // Konrtruktor:
        public Game()
        {
            // Spielfeld zeichnen
            Field.Draw(fieldSize, fieldForeColor, fieldBackColor);
            // Ball instanziieren:
            ball = new Ball(ballCharacter, ballColor, fieldSize);
            // Linken Schläger instanziieren:
            paddleLeft = new Paddle(paddleCharacter, paddleSize, paddleLeftColor, 
                new Vector2D(paddleOffset -1, (fieldSize.Y - paddleSize) / 2), 
                paddleSpeed, fieldSize);

            paddleRight = new Paddle(paddleCharacter, paddleSize, paddleRightColor,
                new Vector2D(fieldSize.X - paddleOffset, (fieldSize.Y - paddleSize) / 2),
                paddleSpeed, fieldSize);

            game1 = new PointSystem(ball, paddleLeft, paddleLeftColor, paddleRight, paddleRightColor, fieldSize, paddleOffset,  ballColor);
        }


        public void Run()
        {
            int x = Console.WindowWidth / 2;
            int y = 0;
            Console.SetCursorPosition(x, y);
            Console.Write('■'); //mit ALT + 254 zeichnen

            DateTime t0, t1;
            Vector2D ballPosition;

            GameScreen.GameStartScreen(fieldSize);

            t0 = DateTime.Now;
            // Game Loop:
            while (runGameLoop)
            {
                t1 = DateTime.Now;
                int ms = (t1.Millisecond - t0.Millisecond + 1000) % 1000;
                // Die im folgenden if-Block enthaltenen Anweisungen werden
                // immer nach Ablauf von timeLoop ms ausgeführt:
                if (ms > loopTime)
                {
                    t0 = t1;

                    runGameLoop = UserInput.GetKeyState(paddleLeft, paddleRight);

                    // Schlägerposition aktualisieren
                    UserInput.GetKeyState(paddleLeft, paddleRight);
                    // Ballposition aktualisieren:
                    ball.Update(paddleLeft, paddleRight);
                    // Mittellinie zeichnen:
                    Field.DrawCenterLine();
                    // Ball zeichnen
                    ballPosition = ball.Draw();
                    //Wandberührung des Balls abfragen
                    game1.CheckScore(ballPosition);
                    

                    // Linken Schläger zeichnen:
                    paddleLeft.Draw();
                    // Rechten Schläger zeichnen:
                    paddleRight.Draw();

                    Field.DrawCenterLine();

                    // Punktezähler anzeigen:
                    game1.DrawScores();
                }
            }
            GameScreen.GameEndScreen(fieldSize);
        }
    }
}
