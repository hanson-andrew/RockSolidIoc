using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{
  [TestClass]
  public class AttributeCollectionFixture
  {
    [TestMethod]
    public void TestAttributeCollection()
    {
      AttributeCollection attributes = new AttributeCollection();
      Attribute attr = new Attribute();
      attr.LocalName = "attr";
      attributes["key"] = attr;
      Assert.AreEqual(attributes["key"], attr);

      Attribute newAttr = new Attribute();
      newAttr.LocalName = "newAttr";
      attributes["key"] = newAttr;
      Assert.AreEqual(attributes["key"], newAttr);
    }
  }
}
