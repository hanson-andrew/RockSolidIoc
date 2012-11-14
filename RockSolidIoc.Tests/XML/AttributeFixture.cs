using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{
  [TestClass()]
  public class AttributeFixture
  {
    [TestMethod()]
    public void TestQName()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      Assert.AreEqual(attribute.QName, String.Empty);
      attribute.QName = "testing_qname";
      Assert.AreEqual(attribute.QName, "testing_qname");
    }

    [TestMethod()]
    public void TestUri()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      Assert.AreEqual(attribute.Uri, String.Empty);
      attribute.Uri = "testing_uri";
      Assert.AreEqual(attribute.Uri, "testing_uri");
    }

    [TestMethod()]
    public void TestLocalName()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      Assert.AreEqual(attribute.LocalName, String.Empty);
      attribute.LocalName = "testing_localname";
      Assert.AreEqual(attribute.LocalName, "testing_localname");
    }

    [TestMethod()]
    public void TestValue()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      Assert.AreEqual(attribute.Value, String.Empty);
      attribute.Value = "testing_value";
      Assert.AreEqual(attribute.Value, "testing_value");
    }

    [TestMethod()]
    public void TestHashCode()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      attribute.LocalName = "localname";
      attribute.QName = "qname";
      attribute.Uri = "uri";
      attribute.Value = "value";
      JordansLibrary.Xml.Attribute equivalentAttribute = new JordansLibrary.Xml.Attribute();
      equivalentAttribute.LocalName = "localname";
      equivalentAttribute.QName = "qname";
      equivalentAttribute.Uri = "uri";
      equivalentAttribute.Value = "value";
      JordansLibrary.Xml.Attribute similarAttribute = new JordansLibrary.Xml.Attribute();
      similarAttribute.LocalName = "localname";
      similarAttribute.QName = "qname";
      similarAttribute.Uri = "uri";
      similarAttribute.Value = "value.";
      Assert.AreEqual(attribute.GetHashCode(), equivalentAttribute.GetHashCode());
      Assert.AreNotEqual(attribute.GetHashCode(), similarAttribute.GetHashCode());
    }

    [TestMethod()]
    public void TestEquals()
    {
      JordansLibrary.Xml.Attribute attribute = new JordansLibrary.Xml.Attribute();
      attribute.LocalName = "localname";
      attribute.QName = "qname";
      attribute.Uri = "uri";
      attribute.Value = "value";
      JordansLibrary.Xml.Attribute attribute2 = new JordansLibrary.Xml.Attribute();
      attribute2.LocalName = "localname";
      attribute2.QName = "qname";
      attribute2.Uri = "uri";
      attribute2.Value = "value";
      Assert.IsTrue(attribute.Equals(attribute2));
      attribute2.LocalName = "localname2";
      Assert.IsFalse(attribute.Equals(attribute2));
      Object obj = new Object();
      Assert.IsFalse(attribute.Equals(obj));
    }
  }
}