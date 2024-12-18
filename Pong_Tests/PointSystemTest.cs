using ConsolePong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Tests
{
    [TestClass]
    public class PointSystemTest
    {
        [TestMethod]
        public void TestCheckScore()
        {
            Vector2D fieldSize = new Vector2D(80, 25);
            Ball fillerBall = new Ball('0', ConsoleColor.Yellow, new Vector2D(fieldSize.X/2, fieldSize.Y/2));
            Paddle fillerPaddle = new Paddle('0', 4, ConsoleColor.Yellow, new Vector2D(10, 10), 0, fieldSize);
            PointSystem testPoints = new PointSystem(fillerBall, fillerPaddle, ConsoleColor.Yellow, fillerPaddle, ConsoleColor.Yellow, fieldSize, 0, ConsoleColor.Yellow);
            Random random = new Random();
            Vector2D ballTestPosition = new Vector2D(random.Next(0, fieldSize.X + 1), random.Next(0, fieldSize.Y + 1));
            for (int i = 0; i < 1000; i++) {
                if (ballTestPosition.X == 0)
                    Assert.AreEqual("right player score test string (do not delete)", testPoints.CheckScore(ballTestPosition), "Der Score des rechten Spielers wird nicht korrekt erhöht, wenn das Paddle den linken Rand berührt");
                else if (ballTestPosition.X == fieldSize.X - 1)
                    Assert.AreEqual("left player score test string (do not delete)", testPoints.CheckScore(ballTestPosition), "Der Score des linken Spielers wird nicht korrekt erhöht, wenn das Paddle den rechten Rand berührt");
                else
                    Assert.AreEqual("no return test string (do not delete)", testPoints.CheckScore(ballTestPosition), "Der Score wird verändert, obwohl das Paddle keinen der beiden Spielfeldränder berührt");
            }
        }
    }
}
