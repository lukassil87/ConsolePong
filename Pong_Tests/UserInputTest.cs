using ConsolePong;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static Pong_Tests.UserInputTest;
namespace Pong_Tests
{
    [TestClass]
    public class UserInputTest
    {
        [TestMethod]
        public void TestGetKeyStatePaddle()
        {
            Assert.Fail("Um die GetKeyState() Methode zu testen, muss das ConsolePong Programm ausgeführt werden, anschließend kann diese Zeile gelöscht werden");
            Assert.IsTrue(true, "Diese Zeile sollte in der TestField-Methode verbleiben, wenn die GetKeyState() Methode in der Konsole die Paddlebewegung beim richtigen Tastendruck ausgibt");
        }

        [TestMethod]
        public void TestGetKeyStateESC()
        {
            Assert.Fail("Um die GetKeyState() Methode zu testen, muss das ConsolePong Programm ausgeführt werden, anschließend kann diese Zeile gelöscht werden");
            Assert.IsTrue(true, "Diese Zeile sollte in der TestField-Methode verbleiben, wenn die GetKeyState() beim Tastendruck <Escape> das Programm beendet");
        }
    }
}
