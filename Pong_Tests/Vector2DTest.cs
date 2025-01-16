using ConsolePong;
using System.Reflection.Metadata;

namespace Pong_Tests
{
    [TestClass]
    public class Vector2DTest
    {
        [TestMethod]
        public void TestVectorConstructorAndProperties()
        {
            int testX = 4;
            int testY = 3;
            Vector2D testVec = new Vector2D(testX, testY);
            Assert.AreEqual(testX, testVec.X);
            Assert.AreEqual(testY, testVec.Y);
        }

        [TestMethod]
        public void TestPlusOperator()
        {
            Random rand = new Random();
            int testX = 4;
            int testY = 3;
            int[] additionXValues = new int[10];
            int[] additionYValues = new int[10];
            Vector2D[] additionVectors = new Vector2D[10];
            Vector2D testVec = new Vector2D(testX, testY);

            for (int i = 0; i < 10; i++)
            {
                additionXValues[i] = rand.Next(-1000, 1000);
                additionYValues[i] = rand.Next(-1000, 1000);
            }
            for (int i = 0; i < 10; i++)
            {
                additionVectors[i] = new Vector2D(additionXValues[i], additionYValues[i]);
            }

            for (int i = 0; i < additionVectors.Length; i++)
            {
                testVec += additionVectors[i];
                Vector2D compare = new Vector2D(testVec.X += additionXValues[i], testVec.Y += additionYValues[i]);
                Assert.AreEqual(testVec.X, compare.X);
                Assert.AreEqual(testVec.Y, compare.Y);
            }
        }
    }
}
