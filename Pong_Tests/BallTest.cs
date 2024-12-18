using ConsolePong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Tests
{

    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void TestBallConstructorAndProperties()
        {
            char character = '█';
            ConsoleColor ballColor = ConsoleColor.Green;
            Vector2D fieldSize = new Vector2D(80, 25);

            Ball testBall = new Ball(character, ballColor, fieldSize);
            testBall.Color = ConsoleColor.Yellow;
            try
            {
                Assert.AreEqual(testBall.Color, ConsoleColor.Yellow, "Die Property Color wird nicht korrekt gesetzt (Hinweis: möglicherweise wird der Property der falsche Wert zugewiesen, oder dieser wird im Konstruktor falsch zugewiesen)");
                Assert.IsTrue((testBall.Position.X == fieldSize.X / 2) == (testBall.Position.Y == fieldSize.Y / 2 - 1), "Die Ball positionNew wird nicht korrekt gesetzt (Hinweis: möglicherweise wird das Feld nicht richtig gesetzt, oder positionStart wird falsch gesetzt)");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void TestBallReset()
        {
            char character = '█';
            ConsoleColor ballColor = ConsoleColor.Green;
            Vector2D fieldSize = new Vector2D(80, 25);
            int velocityLeftCount = 0;
            int velocityRightCount = 0;

            Ball testBall = new Ball(character, ballColor, fieldSize);
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    testBall.Reset();
                    if (testBall.Velocity.X < 0)
                        velocityLeftCount++;
                    else if (testBall.Velocity.X > 0)
                        velocityRightCount++;
                    Assert.IsTrue(testBall.Velocity.Y == 0, "Die Ball Reset Methode setzt die Y-Bewegung des Balls nicht korrekt auf 0 zurück");
                    Assert.IsTrue((testBall.Position.X == fieldSize.X / 2) == (testBall.Position.Y == fieldSize.Y / 2 - 1), "Die Ball Reset Methode setzt die Position des Balls nicht korrekt auf die Startposition zurück");
                }
                Assert.IsTrue((velocityLeftCount > 400) == (velocityLeftCount < 600) == (velocityRightCount > 400) == (velocityRightCount < 600) == (velocityLeftCount + velocityRightCount == 1000),
                    "Die Reset Methode gibt nicht die korrekte 50/50 Verteilung von Bewegung nach links und rechts zurück");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
