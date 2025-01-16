using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePong;

namespace Pong_Tests
{
    [TestClass]
    public class CollisionDetectionTest
    {
        [TestMethod]
        public void PaddleRightCollisionTest()
        {
            char paddleCharacter = '█';
            int paddleSize = 4;
            int paddleSpeed = 1;
            Vector2D fieldSize = new Vector2D(80, 25);
            Vector2D paddleStartPosition = new Vector2D(fieldSize.X - 6, (fieldSize.Y - paddleSize) / 2);
            ConsoleColor paddleLeftColor = ConsoleColor.Green;
            Paddle paddleRight = new Paddle(paddleCharacter, paddleSize, paddleLeftColor,
                paddleStartPosition, paddleSpeed, fieldSize);

            Vector2D ballPosition = new Vector2D(10, 10);
            Vector2D velocity = new Vector2D(4, 0);

            CollisionDetection.paddleRightCollision(ballPosition, paddleRight, ref velocity);
            Assert.AreEqual(4, velocity.X, "Eine Kollision wird falsch erkannt und die X-Koordinate der Geschwindikeit verändert");
            Assert.AreEqual(0, velocity.Y, "Eine Kollision wird falsch erkannt und die Y-Koordinate der Geschwindikeit verändert");

            ballPosition.X = paddleRight.Position.X - 1;
            ballPosition.Y = paddleRight.Position.Y + paddleRight.Size / 3 - 1;

            CollisionDetection.paddleRightCollision(ballPosition, paddleRight, ref velocity);

            Assert.AreEqual(-4, velocity.X, "Eine Kollision am unteren Ende des Paddles wird nicht erkannt und die Geschwindigkeit nicht invertiert");
            Assert.AreEqual(-1, velocity.Y, "Eine Kollision am unteren Ende des Paddles setzt die Y-Koordinate der Geschwindikeit nicht korrekt");

            ballPosition.X = paddleRight.Position.X - 1;
            ballPosition.Y = paddleRight.Position.Y + paddleRight.Size / 3 + 1;
            velocity = new Vector2D(4, 0);

            CollisionDetection.paddleRightCollision(ballPosition, paddleRight, ref velocity);

            Assert.AreEqual(-4, velocity.X, "Eine Kollision in der Mitte des Paddles wird nicht erkannt und die Geschwindigkeit nicht invertiert");
            Assert.AreEqual(0, velocity.Y, "Eine Kollision in der Mitte des Paddles setzt die Y-Koordinate der Geschwindikeit nicht korrekt");

            ballPosition.X = paddleRight.Position.X - 1;
            ballPosition.Y = paddleRight.Position.Y + paddleRight.Size / 3 + 2;
            velocity = new Vector2D(4, 0);

            CollisionDetection.paddleRightCollision(ballPosition, paddleRight, ref velocity);

            Assert.AreEqual(-4, velocity.X, "Eine Kollision am oberen Ende des Paddles wird nicht erkannt und die Geschwindigkeit nicht invertiert");
            Assert.AreEqual(1, velocity.Y, "Eine Kollision am oberen Ende des Paddles setzt die Y-Koordinate der Geschwindikeit nicht korrekt");
        }
    }
}
