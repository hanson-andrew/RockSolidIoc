using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{
  [TestClass()]
  public class DocumentFixture
  {

    [TestMethod()]
    public void TestRootNode()
    {
      Mock<IElement> rootNode = new Mock<IElement>();
      Document document = new Document(rootNode.Object);
      Assert.AreEqual(document.RootNode, rootNode.Object);

      Mock<IElement> rootNode2 = new Mock<IElement>();
      document.RootNode = rootNode2.Object;
      Assert.AreEqual(document.RootNode, rootNode2.Object);
    }
  }
}
