using ConsolePong;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Pong_Tests
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void TestField() 
        {
            Assert.Fail("Um die DrawCenterLine() Methode zu testen, muss das ConsolePong Programm ausgeführt werden, anschließend kann diese Zeile gelöscht werden");
            Assert.IsTrue(true, "Diese Zeile sollte in der TestField-Methode verbleiben, wenn die DrawCenterLine() Methode entsprechend der Angabe funktioniert");
        }
    }
}
