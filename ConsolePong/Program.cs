using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    internal class Program
    {
        static void Main(string[] args)
        {

            new Game().Run();
        }
    }

    class TestPaddle : Paddle
    {
        string paddleName;
        Vector2D positionNew;

        public TestPaddle(string paddleName, char character, int size, ConsoleColor color, Vector2D position, Vector2D fieldSize) : base(character, size, color, position, 0, fieldSize)
        {
            this.paddleName = paddleName;
            positionNew = position;
        }
        public override void Update(string move)
        {
            switch (move)
            {
                case "up":
                    Console.SetCursorPosition(positionNew.X, positionNew.Y);
                    Console.Write(paddleName + " is moving up  ");
                    break;
                case "down":
                    Console.SetCursorPosition(positionNew.X, positionNew.Y);
                    Console.Write(paddleName + " is moving down");
                    break;
            }
        }
    }
}
