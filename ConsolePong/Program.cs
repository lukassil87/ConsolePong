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
            Vector2D fieldSize = new Vector2D(80, 25);

            TestPaddle leftPaddle = new TestPaddle("Left Paddle", '█', 4, ConsoleColor.Green, new Vector2D(10, 10), fieldSize);
            TestPaddle rightPaddle = new TestPaddle("Right Paddle", '█', 4, ConsoleColor.Green, new Vector2D(fieldSize.X - 10, 10), fieldSize);

            Console.CursorVisible = false;

            bool testLoop = true;
            while (testLoop)
            {
                Field.DrawCenterLine();
                testLoop = UserInput.GetKeyState(leftPaddle, rightPaddle);
            }
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
