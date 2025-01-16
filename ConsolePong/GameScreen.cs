using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    static class GameScreen
    {
        // Anzeigedauer festlegen in Sekunden [s]
        static double screenDisplayInSeconds = 1.0;
        public static void GameStartScreen(Vector2D fieldSize)
        {
            // Hier Design einfügen
            string message = "Game is about to start";
            // Text zentrieren
            Console.SetCursorPosition(fieldSize.X / 2 - message.Length / 2, fieldSize.Y / 2 - 1);
            // Text schreiben
            Console.Write(message);
            // für Anzeigedauer stoppen
            System.Threading.Thread.Sleep(((int)(screenDisplayInSeconds * 1000)));
            Console.Clear();
        }

        public static void GameEndScreen(Vector2D fieldSize)
        {
            // Hier Design einfügen
            string message = "Game has just ended";
            // Text zentrieren
            Console.SetCursorPosition(fieldSize.X / 2 - message.Length / 2, fieldSize.Y / 2 - 1);
            // Text schreiben
            Console.Write(message);
            // für Anzeigedauer stoppen
            System.Threading.Thread.Sleep(((int)(screenDisplayInSeconds * 1000)));
            Console.Clear();
        }
    }
}
