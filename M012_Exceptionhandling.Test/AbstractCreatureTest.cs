using M009_Types_Poly;

namespace M012_Exceptionhandling.Test
{
    [TestClass]
    public class AbstractCreatureTest
    {
        [TestMethod]
        public void CompareCreatureReferences_Test() 
        {
            // Arrange
            var creature1 = new HomoSapiens("Max");
            var creature2 = new HomoSapiens("Max");

            // Assert
            Assert.AreNotEqual(creature1, creature2);

            var create1ReferenceCopy = creature1;
            Assert.AreEqual(creature1, create1ReferenceCopy);

            var listOfCreaturesReferences = new List<AbstractCreature> { creature1, creature2 };

            creature1 = null;
            Assert.IsNull(creature1);
            Assert.IsNotNull(create1ReferenceCopy);
            Assert.IsNotNull(listOfCreaturesReferences[0]);
        }
    }
}
