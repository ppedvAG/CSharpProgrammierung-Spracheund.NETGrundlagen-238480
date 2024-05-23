namespace M012_Exceptionhandling.Test
{
    // Das ist ein Attribut was diese Klasse als Testklasse kennzeichnet um vom Test Explorer als solche detektiert wird
    [TestClass]
    public class ExceptionWhileParsingExampleTest
    {
        readonly ExceptionWhileParsingExample uut = new();

        // Wir verwenden das AAA Pattern fuer unseren Test

        // Das ist ein Attribut was diese Methode als Testmethode kennzeichnet um vom Test Explorer aufgelistet wird
        [TestMethod]
        public void ParseDateTime_InalidDate_ReturnsNull()
        {
            // Act: Testausfuehrung
            var actual = uut.ParseDateTime("Ungueltiges Datum");

            // Assert: Testergebnis ueberpruefen
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ParseDateTime_Null_ReturnsNull()
        {
            // Act: Testausfuehrung
            var actual = uut.ParseDateTime(null);

            // Assert: Testergebnis ueberpruefen
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ParseDateTime_ValidDateString_ReturnsDateTime()
        {
            // Arrange: Testvorbereitung
            // uut = unit under test
            int expectedYear = 2000;
            int expectedMonth = 12;
            int expectedDay = 6;
            string dateToTest = $"{expectedYear}-{expectedMonth}-{expectedDay}";

            // Act: Testausfuehrung
            var actual = uut.ParseDateTime(dateToTest);

            // Assert: Testergebnis ueberpruefen
            Assert.IsNotNull(actual, "Erwarteter Wert ist null");
            Assert.AreEqual(expectedYear, actual.Value.Year, "Erwartetes Jahr nicht gleich");
            Assert.AreEqual(expectedMonth, actual.Value.Month, "Erwartetes Jahr nicht gleich");
            Assert.AreEqual(expectedDay, actual.Value.Day, "Erwartetes Jahr nicht gleich");

            var expectedDate = new DateTime(2000, 12, 6);
            Assert.AreEqual(expectedDate, actual.Value);
        }

        [TestMethod]
        [DataRow("2000-12-6")]
        [DataRow("6. Dezember 2000")]
        //[DataRow("Ungueltiges Datum")]
        public void ParseDateTime_ValidDateByArguments_ReturnsDateTime(string dateToTest)
        {
            // Act: Testausfuehrung
            var actual = uut.ParseDateTime(dateToTest);

            // Assert: Testergebnis ueberpruefen
            Assert.IsNotNull(actual, "Erwarteter Wert ist null");

            var expectedDate = new DateTime(2000, 12, 6);
            Assert.AreEqual(expectedDate, actual.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(MyAwesomeException))]
        public void ThrowAnExceptionJustForFun_ThrowsNullReferenceException1()
        {
            // Act: Testausfuehrung
            uut.ThrowAnExceptionJustForFun();
        }

        [TestMethod]
        public void ThrowAnExceptionJustForFun_ThrowsNullReferenceException2()
        {
            // Act: Testausfuehrung
            Assert.ThrowsException<MyAwesomeException>(() => uut.ThrowAnExceptionJustForFun());
        }
    }
}