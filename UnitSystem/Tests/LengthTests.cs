using NUnit.Framework;
using static UnitSystem.Length.Unit;
using static UnitSystem.Length;


namespace UnitSystem.Tests
{
    [TestFixture]
    class LengthTests
    {
        [Test]
        public void TestDefaultValue()
        {
            var length = new Length();
            Assert.AreEqual(length.Value, 0);
        }

        [Test]
        public void TestAssignment()
        {
            Length l1 = new Length(0.4);
            Length l2 = new Length(40, Centimeter);
            Length l3 = "4dm";
            Assert.AreEqual(l1.Value, l2.Value, 0.00000001);
            Assert.AreEqual(l1.Value, l3.Value, 0.00000001);
        }

        [Test]
        public void Test()
        {
            var l1 = new Length(0.4);
            Assert.AreEqual("40 cm", l1.ToString(Centimeter));
            Assert.AreEqual("4 dm", l1.ToString(Decimeter, "G1", null));
            Assert.AreEqual("0.4 m", l1.ToString("F1", null));
        }
    }
}
