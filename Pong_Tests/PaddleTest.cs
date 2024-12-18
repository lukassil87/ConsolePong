using ConsolePong;
using System.Reflection.Metadata;

namespace Pong_Tests
{
    [TestClass]
    public class PaddleTest
    {
        [TestMethod]
        public void TestPaddleConstructorAndProperties()
        {
            char paddleCharacter = '█';
            int paddleSize = 4;
            int paddleSpeed = 1;
            Vector2D fieldSize = new Vector2D(80, 25);
            Vector2D paddlePosition = new Vector2D(10, 10);
            ConsoleColor paddleLeftColor = ConsoleColor.Green;
            Paddle testPaddle = new Paddle(paddleCharacter, paddleSize, paddleLeftColor,
                paddlePosition, paddleSpeed, fieldSize);
            try
            {
                Assert.AreEqual(paddleSize, testPaddle.Size, "Die Property Size kann nicht korrekt ausgelesen werden (Hinweis: möglicherweise gibt die Property den Falschen Wert zurück, oder dieser wird im Konstruktor falsch zugewiesen)");
                Assert.AreEqual(paddlePosition, testPaddle.Position, "Die Property Position kann nicht korrekt ausgelesen werden (Hinweis: möglicherweise gibt die Property den Falschen Wert zurück, oder dieser wird im Konstruktor falsch zugewiesen)");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestPaddleUpdate()
        {
            char paddleCharacter = '█';
            int paddleSize = 4;
            int paddleSpeed = 1;
            Vector2D fieldSize = new Vector2D(100, 100);
            Vector2D paddleStartPosition = new Vector2D(5, 50);
            ConsoleColor paddleLeftColor = ConsoleColor.Green;
            Paddle testPaddle = new Paddle(paddleCharacter, paddleSize, paddleLeftColor,
                paddleStartPosition, paddleSpeed, fieldSize);

            for (int i = 1; i < 10; i++)
            {
                testPaddle.Update("up");
                testPaddle.UpdatePosition();
                Assert.AreEqual(paddleStartPosition.Y -= paddleSpeed, testPaddle.Position.Y, "Das Paddle bewegt sich nicht richtig nach oben (Hinweis: auf den Aufbau des Koordinatensystems in der Konsole achten)");
            }
            
            for (int i = 1; i < 10; ++i)
            {
                testPaddle.Update("down");
                testPaddle.UpdatePosition();
                Assert.AreEqual(paddleStartPosition.Y += paddleSpeed, testPaddle.Position.Y, "Das Paddle bewegt sich nicht richtig nach unten (Hinweis: auf den Aufbau des Koordinatensystems in der Konsole achten)");
            }
            paddleSpeed = 4;

            Paddle testFastPaddle = new Paddle(paddleCharacter, paddleSize, paddleLeftColor,
                paddleStartPosition, paddleSpeed, fieldSize);
            for (int i = 1; i < 10; i++)
            {
                testFastPaddle.Update("up");
                testFastPaddle.UpdatePosition();
                Assert.AreEqual(paddleStartPosition.Y -= paddleSpeed, testFastPaddle.Position.Y, "Das Paddle bewegt sich nicht entsprechend des Paddle speeds nach oben (Hinweis: darauf achten den speed und keine Konstante beim Berechnen der Bewegung zu verwenden)");
            }

            for (int i = 1; i < 10; ++i)
            {
                testFastPaddle.Update("down");
                testFastPaddle.UpdatePosition();
                Assert.AreEqual(paddleStartPosition.Y += paddleSpeed, testFastPaddle.Position.Y, "Das Paddle bewegt sich nicht entsprechend des Paddle speeds nach unten (Hinweis: darauf achten den speed und keine Konstante beim Berechnen der Bewegung zu verwenden)");
            }
        }
    }
}