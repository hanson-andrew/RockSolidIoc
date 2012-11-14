using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{

  [TestClass()]
  public class ElementFixture
  {

    [TestMethod()]
    public void TestTextlessConstructor()
    {
      string namespaceUri = "namespaceUri";
      string localName = "localname";
      string qualifiedName = "qualifiedname";
      var parent = new Mock<IElement>();
      List<IElement> children = new List<IElement>();
      AttributeCollection attributes = new AttributeCollection();
      Element element = new Element(namespaceUri, localName, qualifiedName, parent.Object, children, attributes);

      for (int i = 0; i < 10; i++)
      {
        children.Add(new Mock<IElement>() as IElement);
      }

      IList<IElement> parentChildren = new List<IElement>();
      parent.Setup(c => c.ChildElements).Returns(parentChildren);

      var previousSiblingStub = new Mock<IElement>();
      parentChildren.Add(previousSiblingStub.Object);
      parentChildren.Add(element);

      Assert.AreEqual(element.Attributes, attributes);
      Assert.AreEqual(element.ChildElements, children);
      Assert.AreEqual(element.FirstElement, children[0]);
      Assert.IsTrue(element.HasChildNodes);
      Assert.AreEqual(element.LastElement, children[9]);
      Assert.AreEqual(element.LocalName, localName);
      Assert.AreEqual(element.Name, qualifiedName);
      Assert.AreEqual(element.NamespaceUri, namespaceUri);
      Assert.AreEqual(element.ParentElement, parent.Object);
      Assert.AreEqual(element.PreviousSibling, previousSiblingStub.Object);
      Assert.AreEqual(element.TextContent, string.Empty);
    }

    [TestMethod()]
    public void TestTextConstructor()
    {
      string namespaceUri = "namespaceUri";
      string localName = "localname";
      string qualifiedName = "qualifiedname";
      var parent = new Mock<IElement>();
      IList<IElement> children = new List<IElement>();
      AttributeCollection attributes = new AttributeCollection();
      string text = "testing_text_value";
      Element element = new Element(namespaceUri, localName, qualifiedName, parent as IElement, children, attributes, text);
      Assert.AreEqual(element.TextContent, text);
    }

    [TestMethod()]
    public void TestNoSiblingsFound()
    {
      string namespaceUri = "namespaceUri";
      string localName = "localname";
      string qualifiedName = "qualifiedname";
      Mock<IElement> parent = null;
      IList<IElement> children = new List<IElement>();
      AttributeCollection attributes = new AttributeCollection();
      Element element = new Element(namespaceUri, localName, qualifiedName, parent as IElement, children, attributes);
      Assert.IsNull(element.PreviousSibling);
      namespaceUri = "namespaceUri";
      localName = "localname";
      qualifiedName = "qualifiedname";
      parent = new Mock<IElement>();
      children = new List<IElement>();
      attributes = new AttributeCollection();
      element = new Element(namespaceUri, localName, qualifiedName, parent as IElement, children, attributes);

      IList<IElement> parentChildren = new List<IElement>();
      parent.Setup(c => c.ChildElements).Returns(parentChildren);

      var previousSiblingStub = new Mock<IElement>();
      parentChildren.Add(element);
      Assert.IsNull(element.PreviousSibling);
    }

    [TestMethod()]
    public void TestRootNodePreviousSiblings()
    {
      string namespaceUri = "namespaceUri";
      string localName = "localname";
      string qualifiedName = "qualifiedname";
      var parent = new Mock<IElement>();
      List<IElement> children = new List<IElement>();
      AttributeCollection attributes = new AttributeCollection();
      Element element = new Element(namespaceUri, localName, qualifiedName, parent.Object, children, attributes);

      IList<IElement> parentChildren = new List<IElement>();
      parent.Setup(c => c.ChildElements).Returns(parentChildren);
      parentChildren.Add(element);
      
      Assert.IsNull(element.PreviousSibling);
    }

  }

}