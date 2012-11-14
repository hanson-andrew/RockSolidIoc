using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{

  [TestClass()]
  public class SaxReadersImplFixture
  {

    private string _xmlToParse = @"<?xml version=""1.0"" encoding=""UTF-8""?><root><element1></element1><element2 /><element3 attr1=""val1"">Test</element3></root>";

    [TestMethod()]
    public void TestParse()
    {
      var saxHandler = new Mock<ISaxHandler>();

      using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
      {
        memoryStream.Write(new System.Text.UTF8Encoding().GetBytes(_xmlToParse), 0, _xmlToParse.Length);
        memoryStream.Position = 0;


        SaxReaderImpl saxReaderImpl = new SaxReaderImpl();
        saxReaderImpl.Parse(new System.IO.StreamReader(memoryStream), saxHandler.Object);
      }


      AttributeCollection element3Attributes = new AttributeCollection();
      Attribute attr1Attribute = new Attribute();
      attr1Attribute.LocalName = "attr1";
      attr1Attribute.QName = "attr1";
      attr1Attribute.Uri = string.Empty;
      attr1Attribute.Value = "val1";
      element3Attributes.Add("attr1", attr1Attribute);

      saxHandler.Verify(c => c.StartDocument(), Times.Exactly(1));
      saxHandler.Verify(c => c.EndDocument(), Times.Exactly(1));
      saxHandler.Verify(c => c.StartElement(string.Empty, "root", "root", new AttributeCollection()));
      saxHandler.Verify(c => c.StartElement(string.Empty, "element1", "element1", new AttributeCollection()));
      saxHandler.Verify(c => c.StartElement(string.Empty, "element2", "element2", new AttributeCollection()));
      saxHandler.Verify(c => c.StartElement(string.Empty, "element3", "element3", element3Attributes));
      saxHandler.Verify(c => c.EndElement(string.Empty, "root", "root"));
      saxHandler.Verify(c => c.EndElement(string.Empty, "element1", "element1"));
      saxHandler.Verify(c => c.EndElement(string.Empty, "element2", "element2"));
      saxHandler.Verify(c => c.EndElement(string.Empty, "element3", "element3"));
      saxHandler.Verify(c => c.Characters(It.IsAny<char[]>(), It.IsAny<int>(), It.IsAny<int>()));
    }

  }

}