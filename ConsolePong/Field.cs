using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    static class Field
    {
        // Konsolenfenster als Pong-Spielfeld konfigurieren und formatieren:
        public static void Draw(Vector2D size, ConsoleColor foreCoIor, ConsoleColor backColor) {
            // Fenstertitel setzen:
            Console.Title = "CONSOLRE PONG";
            // Fenster-Größe setzen
            Console.SetWindowSize(size.X, size.Y);
            // Buffer-Größe setzen, um Scroll-Balken zu vermeiden:
            Console.SetBufferSize(size.X, size.Y);
            // Vorder- und Hintergrundfarbe setzen
            Console.ForegroundColor = foreCoIor;
            Console.BackgroundColor = backColor;
            // Fensterinhalt löschen, um Farbeinstellungen anzuwenden
            Console.Clear();
            // Verwendung von Unicode-Zeichen ermöglichen:
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Cursor unsichtbar machen:
            Console.CursorVisible = false;
            // Mittellinie zeichnen
            DrawCenterLine();
        }

        /* T1-Klasse 01 - Aufgabe_1
         * 
         * Programmiere die DrawCenterLine-Methode, sodass das Spielfeld wie im Notebook anbgegeben gezeichnet wird
         * 
         * Zu verwendende Methoden und Eigenschaften:
         * - Console.WindowWidth
         * - Console.WindowHeight
         * - Console.SetCursorPosition(<X>, <Y>)
         * - 'Console.Write("|");
        */
        public static void DrawCenterLine()
        {
            for(int i = 0; i < Console.WindowHeight; i++)
            {
                // TODO A_1
            }
        }
    }
}
