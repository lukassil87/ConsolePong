using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsolePong
{
    public class UserInput
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Int32 vKey);

        
        static public bool GetKeyState(Paddle paddleLeft, Paddle paddleRight)
        {
            
            if (Console.KeyAvailable)
            {
                /* T1-Klasse 02 - Aufgabe_1
                 * 
                 * Die gegebene if-Bedingung, bewegt das linke Paddle nach oben, wenn <W> gedrückt wird
                 * 
                 * Erweitere die Methode um drei weitere if-Bediungen, die die folgenden Funktionen erüllen sollen:
                 * - linkes Paddle nach unten bewegen
                 * - rechtes Paddle nach oben bewegen
                 * - rechtes Paddle nach unten bewegen
                */

                if (GetAsyncKeyState((int)ConsoleKey.W) != 0)
                    paddleLeft.Update("up"); // "down" würde das Paddle nach unten bewegen
                if (GetAsyncKeyState((int)ConsoleKey.S) != 0)
                    paddleLeft.Update("down");
                if (GetAsyncKeyState((int)ConsoleKey.O) != 0)
                    paddleRight.Update("up");
                if (GetAsyncKeyState((int)ConsoleKey.L) != 0)
                    paddleRight.Update("down");

                // TODO A_1

                /* T1-Klasse 02 - Aufgabe_2
                 * 
                 * Füge eine weitere Abfrage ein, die den Status der Escape-Taste bestimmt.
                 * Dieser Block soll false zurückgeben, sollte die Taste gedrückt werden.
                */

                // TODO A_2
                if (GetAsyncKeyState((int)ConsoleKey.Escape) != 0) 
                return false;

            }
            return true;
        }
    }
}
